USE [MM.ServerMonitoring.Database]
GO
INSERT [dbo].[Action] ([Id], [Name], [Description]) VALUES (N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'Ping', N'NetPing')
GO
INSERT [dbo].[TargetTyp] ([Id], [Name], [Description]) VALUES (N'e7db0940-50f9-4333-a794-091bc34e2ff3', N'IP', N'IP')
GO
INSERT [dbo].[Target] ([Id], [TargetTypId], [Name]) VALUES (N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', N'e7db0940-50f9-4333-a794-091bc34e2ff3', N'127.0.0.1')
GO
INSERT [dbo].[Monitor] ([Id], [ActionId], [TargetId], [Name], [Description]) VALUES (N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', N'127.0.0.1', N'127.0.0.1')
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'47fb99a8-8f32-44d8-a84e-00d08c3d0a1e', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:33.007' AS DateTime), CAST(N'2022-10-03T11:25:33.080' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'a57b7d3a-392b-44ea-a97e-0a544a01a332', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:16.707' AS DateTime), CAST(N'2022-10-03T11:24:16.920' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'd0ffbb93-214b-42c5-b883-0e4d9181c53e', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:47.413' AS DateTime), CAST(N'2022-10-03T11:24:47.440' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'11532f4e-8c10-4b33-a983-0fa248c2a540', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:13.463' AS DateTime), CAST(N'2022-10-03T11:26:13.490' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'ba7084bb-cf15-48e0-bc65-2ba4dceaa569', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:32.273' AS DateTime), CAST(N'2022-10-03T11:24:32.313' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'cfd59d44-a193-4741-add0-383f4883447f', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:43.180' AS DateTime), CAST(N'2022-10-03T11:25:43.203' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'8d45ff79-8865-4719-94b6-3b3baf9c84da', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:08.413' AS DateTime), CAST(N'2022-10-03T11:26:08.447' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'a3a3bff6-c21e-4598-9533-460943e960a8', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:12.763' AS DateTime), CAST(N'2022-10-03T11:25:12.793' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'2ec57b15-e698-436d-8e21-46e513980b43', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:22.877' AS DateTime), CAST(N'2022-10-03T11:25:22.903' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'185d5d06-5fd1-4346-b7fc-476333be5d36', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:18.503' AS DateTime), CAST(N'2022-10-03T11:26:18.527' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'fdd1343d-9032-4860-85b6-5292515dd5ce', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:53.273' AS DateTime), CAST(N'2022-10-03T11:25:53.300' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'43910eda-8c6d-4276-92c8-574183c51311', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:58.313' AS DateTime), CAST(N'2022-10-03T11:25:58.347' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'cbdfa3e0-7d5f-4506-b539-7f6d7743535e', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:07.717' AS DateTime), CAST(N'2022-10-03T11:25:07.743' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'b697a7b2-de8c-45a8-a6ba-846f703418e6', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:28.597' AS DateTime), CAST(N'2022-10-03T11:26:28.623' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'f0273f9c-8324-4705-80b0-8a0b582ef256', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:17.827' AS DateTime), CAST(N'2022-10-03T11:25:17.863' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'79795764-cb98-4480-8e37-8a967c14ac50', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:48.223' AS DateTime), CAST(N'2022-10-03T11:25:48.260' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'44a7e1aa-95eb-4ea2-9096-9ace3ea1e00d', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:52.457' AS DateTime), CAST(N'2022-10-03T11:24:52.487' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'e863c884-42a4-42dd-bf1f-9b2f0e164675', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-09-25T16:51:43.630' AS DateTime), CAST(N'2022-09-25T16:51:43.950' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'028af751-532e-460e-b076-b33f63477310', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:38.097' AS DateTime), CAST(N'2022-10-03T11:25:38.157' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'29b85e47-d6fb-49f9-88f4-bccc144be2d8', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:03.363' AS DateTime), CAST(N'2022-10-03T11:26:03.397' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'300bd4e8-21bb-445b-9060-be6916078c49', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:27.223' AS DateTime), CAST(N'2022-10-03T11:24:27.253' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'43ab985d-96a4-4605-a4e7-bf77d0fb6831', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:27.913' AS DateTime), CAST(N'2022-10-03T11:25:27.983' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'28df0ae1-0522-4f4b-a472-ca4aae416704', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:33.643' AS DateTime), CAST(N'2022-10-03T11:26:33.677' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'328d9376-1f48-4c87-8de8-cfaedffdfb5e', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:25:02.637' AS DateTime), CAST(N'2022-10-03T11:25:02.703' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'b7bafa6c-097d-4517-abcc-d11ba0847619', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:42.370' AS DateTime), CAST(N'2022-10-03T11:24:42.403' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'c582702d-3f7b-462f-bb96-d429a5d36695', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:57.503' AS DateTime), CAST(N'2022-10-03T11:24:57.613' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'9e5dff93-f3c1-40ed-ba9c-d665dce060d6', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:22.183' AS DateTime), CAST(N'2022-10-03T11:24:22.213' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'6bf868b7-1468-43e8-918e-d79ae6e592f8', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:26:23.547' AS DateTime), CAST(N'2022-10-03T11:26:23.583' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'74be4b0b-688c-4e35-9493-e17b3c8b9884', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-09-25T16:51:49.193' AS DateTime), CAST(N'2022-09-25T16:51:49.260' AS DateTime))
GO
INSERT [dbo].[MonitorActionExecution] ([Id], [ActionId], [MonitorId], [TargetId], [Success], [Message], [Start], [Finish]) VALUES (N'83d1714b-3df8-4857-92e8-fb0e42999e72', N'86e8c90c-e44e-45b7-a79c-23db2f7d134b', N'39e4cd34-5df1-46df-a340-f2509d1fac10', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', 1, N'', CAST(N'2022-10-03T11:24:37.327' AS DateTime), CAST(N'2022-10-03T11:24:37.357' AS DateTime))
GO
INSERT [dbo].[ParameterTyp] ([Id], [Name], [Description]) VALUES (N'881ed1fa-03b9-4b8f-99a3-d54bd081ac90', N'IP', N'IP')
GO
INSERT [dbo].[Parameter] ([Id], [TargetId], [ParameterTypId], [Value]) VALUES (N'55a9c430-07e6-4a8e-b30a-6c76e5382008', N'808680d0-26c3-487a-b8e3-c2c9dd0fc8a4', N'881ed1fa-03b9-4b8f-99a3-d54bd081ac90', N'8.8.8.8')
GO
