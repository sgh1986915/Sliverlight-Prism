﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Web.Services;

namespace Procbel.Apps.Silverlight.Repository.Main
{
    public abstract class RepositoryBase
    {
        private static AppsmainDomainContext context = new AppsmainDomainContext();

        protected IDictionary<object, bool> EntityLoadingOperations = new Dictionary<object, bool>();

        public AppsmainDomainContext Context
        {
            get
            {
                return RepositoryBase.context;
            }
        }

        public void SaveOrUpdateEntities(Action callback = null)
        {
            System.Diagnostics.Debug.WriteLine("Request for SaveOrUpdateEntities()");
            if (this.Context.IsSubmitting)
            {
                System.Diagnostics.Debug.WriteLine("Returning from SaveOrUpdateEntities.");
                return;
            }
            System.Diagnostics.Debug.WriteLine("this.Context.SubmitChanges()");
            var so = this.Context.SubmitChanges();
            EventHandler submitOperationCompleted = null;
            submitOperationCompleted = (s, e) =>
            {
                so.Completed -= submitOperationCompleted;
                if (so.HasError)
                {
                    this.LogErrorToDebug(so);
                    so.MarkErrorAsHandled();
                }
                if (callback != null)
                {
                    callback();
                }
            };
            so.Completed += submitOperationCompleted;
        }

        protected void LoadQuery<T>(EntityQuery<T> query, Action<IEnumerable<T>> callback)
            where T : Entity
        {
            var key = this.GenerateKeyForObject<T>(query, typeof(T));
            if (this.IsContextLoadingForObject(key))
            {
                return;
            }

            EventHandler onCompleted = null;
            onCompleted = (s, args) =>
            {
                var lo = s as LoadOperation<T>;
                callback(lo.Entities);
                lo.Completed -= onCompleted;
                this.EntityLoadingOperations[key] = false;
                System.Diagnostics.Debug.WriteLine("Loaded query for {0}", key);
            };

            this.EntityLoadingOperations[key] = true;
            var loadOperation = this.Context.Load<T>(query);
            loadOperation.Completed += onCompleted;
        }

        protected void LoadQuery<T>(EntityQuery<T> query, Action<T> callback)
            where T : Entity
        {
            Action<IEnumerable<T>> innerCallback = (o) =>
            {
                if (o == null || o.Count() == 0)
                {
                    callback(default(T));
                    return;
                }

                callback(o.First());
            };

            this.LoadQuery<T>(query, innerCallback);
        }

        protected bool IsContextLoadingForObject(object obj)
        {
            if (this.EntityLoadingOperations.Keys.Contains(obj))
            {
                System.Diagnostics.Debug.WriteLine("Testing {0} for loading - {1}", obj, this.EntityLoadingOperations[obj]);
                return this.EntityLoadingOperations[obj];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Testing {0} for loading - {1}", obj, "ELSE - false");
                this.EntityLoadingOperations.Add(obj, false);
                return false;
            }
        }

        private object GenerateKeyForObject<T>(EntityQuery<T> query, Type t)
            where T : Entity
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(query.QueryName);
            if (query.Parameters != null)
            {
                foreach (var param in query.Parameters)
                {
                    builder.Append(param);
                }
            }
            builder.Append(t.FullName);
            var result = builder.ToString();
            return result;
        }

        private void LogErrorToDebug(SubmitOperation so)
        {
            System.Diagnostics.Debug.WriteLine("ERROR: {0}", so.Error);

            foreach (var entity in so.EntitiesInError)
            {
                foreach (var error in entity.ValidationErrors)
                {
                    foreach (var memberNames in error.MemberNames)
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: {0} {1}...", error.ErrorMessage, memberNames);
                    }
                }
                if (entity.EntityConflict != null)
                {
                    foreach (var propertyName in entity.EntityConflict.PropertyNames)
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: {0} {1}...", entity, propertyName);
                    }
                }
            }
        }
    }
}
