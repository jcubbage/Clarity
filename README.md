James Cubbage submission for C# Skills Checkup for Clarity.

Clarity.MVC includes a views for creating a new notification via form submission, seeing all pending, or details for particular notice. Includes separate API calls for all of these with creating a new notificaiton from JSON.

Clarity.Core contains the notifications class plus services for sending email.
Clarity.Jobs.SendEmail is a console app for attempting to send the emails. This can be used as scheduled task. Requires user secret with a SendGrid API Key.

Database:
Update Appsettings connection string as needed.
One table:

CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [varchar](100) NOT NULL,
	[Recipient] [varchar](100) NOT NULL,
	[Subject] [varchar](100) NOT NULL,
	[Body] [varchar](5000) NOT NULL,
	[DateTimeCreated] [datetime] NOT NULL,
	[DateTimeSent] [datetime] NULL,
	[Attempts] [int] NOT NULL,
	[Pending] [bit] NOT NULL,
	[SendStatusCode] [varchar](50) NULL
) ON [PRIMARY]
GO
