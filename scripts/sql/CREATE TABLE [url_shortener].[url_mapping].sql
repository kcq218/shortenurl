SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [url_shortener].[url_mapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[long_url] [nvarchar](max) NOT NULL,
	[key_id] [int] NOT NULL,
	[hash_value] [varchar](50) NOT NULL,
	[user_id] [int] NULL,
	[active] [bit] NOT NULL,
	[last_accessed] [datetime2](7) NULL,
	[created_by] [varchar](50) NOT NULL,
	[created_date] [datetime2](7) NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[updated_date] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[url_mapping] ADD  CONSTRAINT [PK_url_mapping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[url_mapping] ADD  CONSTRAINT [DEFAULT_url_mapping_active]  DEFAULT ((1)) FOR [active]
GO
