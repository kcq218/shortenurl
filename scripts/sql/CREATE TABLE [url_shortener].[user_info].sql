SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [url_shortener].[user_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[middle_initial] [char](1) NULL,
	[email] [varchar](50) NULL,
	[active] [bit] NOT NULL,
	[last_login] [datetime2](7) NULL,
	[created_by] [varchar](50) NOT NULL,
	[created_date] [datetime2](7) NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[updated_date] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[user_info] ADD  CONSTRAINT [PK_user_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[user_info] ADD  CONSTRAINT [DEFAULT_user_info_active]  DEFAULT ((1)) FOR [active]
GO