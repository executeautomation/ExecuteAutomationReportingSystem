--------------------------------------------------------------------------------------------
-- Name		: ExecuteAutomation Reporting System backend script
-- Author	: Karthik KK
-- Version	: Initial release
--------------------------------------------------------------------------------------------


use Master
Go


CREATE DATABASE EARS_DB
Go

USE EARS_DB
Go
--tblDetailReportTable
CREATE TABLE [dbo].[tblDetailReport](
	[ParentCycleID] [int] NOT NULL,
	[TestReportID] [int] IDENTITY(200,1) NOT NULL,
	[FeatureName] [varchar](100) NULL,
	[ScenarioName] [varchar](800) NULL,
	[StepName] [varchar](1000) NULL,
	[Exception] [varchar](5000) NULL,
	[Result] [varchar](200) NULL,
CONSTRAINT [PK_tblDetailReport] PRIMARY KEY CLUSTERED 
(
	[TestReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--tblFailureReports
CREATE TABLE [dbo].[tblFailureReport](
	[FailureReportID] [int] NOT NULL,
	[FailureDetails] [varchar](5000) NULL,
	[ScreenShot] [binary](1) NULL,
CONSTRAINT [PK_tblFailureReport] PRIMARY KEY CLUSTERED 
(
	[FailureReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--tblTestCycle
CREATE TABLE [dbo].[tblTestCycle](
	[TestCycleID] [int] IDENTITY(100,1) NOT NULL,
	[AUTName] [varchar](40) NULL,
	[ExecutedBy] [varchar](50) NULL,
	[RequestedBy] [varchar](50) NULL,
	[BuildNo] [varchar](50) NULL,
	[ApplicationVersion] [varchar](20) NULL,
	[DateOfExecution] [datetime] NULL,
	[TestType] [int] NULL,
	[MachineName] [varchar](20) NULL,
CONSTRAINT [PK__tblTestC__A34177C17F60ED59] PRIMARY KEY CLUSTERED 
(
	[TestCycleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]

--Foreign Key constraints
ALTER TABLE [dbo].[tblDetailReport]  WITH CHECK ADD  CONSTRAINT [FK_tblDetailReport_ParentCycleID] FOREIGN KEY([ParentCycleID])
REFERENCES [dbo].[tblTestCycle] ([TestCycleID])
GO
ALTER TABLE [dbo].[tblDetailReport] CHECK CONSTRAINT [FK_tblDetailReport_ParentCycleID]
GO
ALTER TABLE [dbo].[tblFailureReport]  WITH CHECK ADD  CONSTRAINT [FK_tblFailureReport_tblDetailReport] FOREIGN KEY([FailureReportID])
REFERENCES [dbo].[tblDetailReport] ([TestReportID])
GO
ALTER TABLE [dbo].[tblFailureReport] CHECK CONSTRAINT [FK_tblFailureReport_tblDetailReport]
GO

