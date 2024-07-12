SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [url_shortener].[generated_keys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hash_value] [varchar](50) NOT NULL,
	[url_id] [int] NULL,
	[active] [bit] NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[created_date] [datetime2](7) NOT NULL,
	[updated_by] [varchar](50) NOT NULL,
	[updated_date] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[generated_keys] ADD  CONSTRAINT [PK_generated_keys] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [url_shortener].[generated_keys] ADD  CONSTRAINT [DEFAULT_generated_keys_active]  DEFAULT ((1)) FOR [active]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'pk incremental int' , @level0type=N'SCHEMA',@level0name=N'url_shortener', @level1type=N'TABLE',@level1name=N'generated_keys', @level2type=N'COLUMN',@level2name=N'id'
GO
