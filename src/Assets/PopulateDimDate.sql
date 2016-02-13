USE [ProcbelApps];
GO

/* FROM http://arcanecode.com/2009/11/18/populating-a-kimball-date-dimension/ */

/*---------------------------------------------------------------------------*/
/* Loads a Date Dimension                                                    */
/*---------------------------------------------------------------------------*/

-- A few notes, this code does nothing to the existing table, no deletes
-- are triggered before hand. Because the Id is uniquely indexed,
-- it will simply produce errors if you attempt to insert duplicates.
-- You can however adjust the Begin/End dates and rerun to safely add
-- new dates to the table every year.
--
-- If the begin date is after the end date, no errors occur but nothing
-- happens as the while loop never executes.

SET NOCOUNT ON -- turn off all the 1 row inserted messages

delete from Dimdates;

-- añadido para definr el formato de fechas
set DATEFORMAT dmy;

-- Hold our dates
DECLARE @BeginDate DATETIME
DECLARE @EndDate DATETIME

-- Holds a flag so we can determine if the date is the last day of month
DECLARE @LastDayOfMon CHAR(1)

-- Number of months to add to the date to get the current Fiscal date
DECLARE @FiscalYearMonthsOffset INT   

-- These two counters are used in our loop.
DECLARE @DateCounter DATETIME    --Current date in loop
DECLARE @FiscalCounter DATETIME  --Fiscal Year Date in loop

-- Set the date to start populating and end populating
SET @BeginDate = '01/01/2013'
SET @EndDate = '31/12/2014' 

-- Set this to the number of months to add to the current date to get
-- the beginning of the Fiscal year. For example, if the Fiscal year
-- begins July 1, put a 6 there.
-- Negative values are also allowed, thus if your 2010 Fiscal year
-- begins in July of 2009, put a -6.
SET @FiscalYearMonthsOffset = 0

-- Start the counter at the begin date
SET @DateCounter = @BeginDate

WHILE @DateCounter <= @EndDate
      BEGIN
            -- Calculate the current Fiscal date as an offset of
            -- the current date in the loop
            SET @FiscalCounter = DATEADD(m, @FiscalYearMonthsOffset, @DateCounter)

            -- Set value for IsLastDayOfMonth
            IF MONTH(@DateCounter) = MONTH(DATEADD(d, 1, @DateCounter))
               SET @LastDayOfMon = 'N'
            ELSE
               SET @LastDayOfMon = 'Y'  

            -- add a record into the date dimension table for this date
            INSERT  INTO [DimDates]
                    (
                      [Id]
                    , [FullDate]
                    , [DateName]
                    , [DateNameUS]
                    , [DateNameEU]
                    , [DayOfWeek]
                    , [DayOfWeekName] --[DayNameOfWeek]
					,[DayOfWeekNameSpanish] -- Añadido
					,[DayOfWeekNameChinese] --añadido
                    , [DayOfMonth]
                    , [DayOfYear]
                    , [WeekdayWeekend]
                    , [WeekOfYear]
                    , [MonthName]
					,[MonthNameSpanish] --añadido
					,[MonthNameChinese] --añadido
                    , [MonthOfYear]
                    , [IsLastDayOfMonth]
                    , [CalendarQuarter]
                    , [CalendarYear]
                    , [CalendarYearMonth]
                    , [CalendarYearQtr]
                    , [FiscalMonthOfYear]
                    , [FiscalQuarter]
                    , [FiscalYear]
                    , [FiscalYearMonth]
                    , [FiscalYearQtr]
                    )
            VALUES  (
                      ( YEAR(@DateCounter) * 10000 ) + ( MONTH(@DateCounter)* 100 )+ DAY(@DateCounter)  --Id
                    , @DateCounter -- FullDate
                    , CAST(YEAR(@DateCounter) AS CHAR(4)) + '/'+ RIGHT('00' + RTRIM(CAST(DATEPART(mm, @DateCounter) AS CHAR(2))), 2) + '/' + RIGHT('00' + RTRIM(CAST(DATEPART(dd, @DateCounter) AS CHAR(2))), 2) --DateName
                    , RIGHT('00' + RTRIM(CAST(DATEPART(mm, @DateCounter) AS CHAR(2))), 2) + '/' + RIGHT('00' + RTRIM(CAST(DATEPART(dd, @DateCounter) AS CHAR(2))), 2)  + '/'  + CAST(YEAR(@DateCounter) AS CHAR(4))--DateName
                    , RIGHT('00' + RTRIM(CAST(DATEPART(dd, @DateCounter) AS CHAR(2))), 2) + '/' + RIGHT('00' + RTRIM(CAST(DATEPART(mm, @DateCounter) AS CHAR(2))), 2)  + '/'  + CAST(YEAR(@DateCounter) AS CHAR(4))--DateName
                    , DATEPART(dw, @DateCounter) --DayOfWeek
                    , DATENAME(dw, @DateCounter) --DayOfWeekName
					,DATENAME(dw,@DateCounter) --WeekdayWeekendSpanish
					,DATENAME(dw,@DateCounter) --WeekdayWeekendChinese
                    , DATENAME(dd, @DateCounter) --DayOfMonth
                    , DATENAME(dy, @DateCounter) --DayOfYear
                    , CASE DATENAME(dw, @DateCounter)
                        WHEN 'Saturday' THEN 'Weekend'
                        WHEN 'Sunday' THEN 'Weekend'
                        ELSE 'Weekday'
                      END --WeekdayWeekend
                    , DATENAME(ww, @DateCounter) --WeekOfYear
                    , DATENAME(mm, @DateCounter) --MonthName
					 , DATENAME(mm, @DateCounter) --MonthNameSpanish
					  , DATENAME(mm, @DateCounter) --MonthNameChinese
                    , MONTH(@DateCounter) --MonthOfYear
                    , @LastDayOfMon --IsLastDayOfMonth
                    , DATENAME(qq, @DateCounter) --CalendarQuarter
                    , YEAR(@DateCounter) --CalendarYear
                    , CAST(YEAR(@DateCounter) AS CHAR(4)) + '-'
                      + RIGHT('00' + RTRIM(CAST(DATEPART(mm, @DateCounter) AS CHAR(2))), 2) --CalendarYearMonth
                    , CAST(YEAR(@DateCounter) AS CHAR(4)) + 'Q' + DATENAME(qq, @DateCounter) --CalendarYearQtr
                    , MONTH(@FiscalCounter) --[FiscalMonthOfYear]
                    , DATENAME(qq, @FiscalCounter) --[FiscalQuarter]
                    , YEAR(@FiscalCounter) --[FiscalYear]
                    , CAST(YEAR(@FiscalCounter) AS CHAR(4)) + '-'
                      + RIGHT('00' + RTRIM(CAST(DATEPART(mm, @FiscalCounter) AS CHAR(2))), 2) --[FiscalYearMonth]
                    , CAST(YEAR(@FiscalCounter) AS CHAR(4)) + 'Q' + DATENAME(qq, @FiscalCounter) --[FiscalYearQtr]
                    )

            -- Increment the date counter for next pass thru the loop
            SET @DateCounter = DATEADD(d, 1, @DateCounter)
      END

SET NOCOUNT ON -- turn the annoying messages back on
