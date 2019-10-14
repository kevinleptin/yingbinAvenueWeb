﻿CREATE TABLE [dbo].[SurveyEntities] (
    [Id] [int] NOT NULL IDENTITY,
    [UserIp] [nvarchar](50),
    [UserLocalId] [nvarchar](50),
    [Subject1] [int] NOT NULL,
    [Subject2] [nvarchar](100) NOT NULL,
    [Subject3] [nvarchar](1000),
    [Subject4] [nvarchar](1000),
    [Subject5] [nvarchar](1000),
    [Subject6] [nvarchar](1000),
    [Subject7] [nvarchar](1000),
    CONSTRAINT [PK_dbo.SurveyEntities] PRIMARY KEY ([Id])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201910131142409_bayerinit', N'yingbinAvenueWeb.Migrations.Configuration',  0x1F8B0800000000000400ED5ADB6EE336107D2FD07F10F49CB5623B4EDAC0DE45626F0A637343946CD1475A1A3B6C254A2B52868DA25FD6877E527FA123EB6AEA66A9B6BBD806798928CE99E1CC8873F3DF7FFE35FCB0B22D65091EA70E1BA9DDCEA9AA00331C93B2C548F5C5FCDD0FEA87F7DF7F37FC68DA2BE573BCAF1FEC434AC647EAAB10EEA5A671E3156CC23B36353C873B73D1311C5B23A6A3F54E4F7FD4BA5D0D1042452C45193EF94C501B360FF838769801AEF08975E79860F1681DDFE81B54E59ED8C05D62C0485DA36433CAAE96C07CF819669D904455AE2C4A501C1DACB9AA10C61C41040A7BF9C241179EC316BA8B0BC47A5EBB80FBE6C4E2101DE232DDBEEB794E7BC179B4943086327C2E1CBB2160B71F294893C95BA9594D14882AFC88AA16EBE0D41B358ED42B974ED9D2F90D9EC0703C5355649E9763CB0BF6972ABB23419C28F2C693C457D0A582BF1365EC5BC2F760C4C0171EB14E94477F6651E313AC9F11888D986F5959C151747CB7B5804B8F9EE38227D64F308F8E33C51368DB749A4C98906568C2134E99E8F754E51E99939905895F64B4A10BC7839F80814704988F4408F05880011BCDE6B84BBC90E035E6868E888A52953BB2BA05B610AF2315CDA62A37740566BC1249F0C2287E8748243C1FEA988C3D40E11E58CC68824FCFF885159C6C17A0EB7585C483E6020FB5D40B2B7D1317BCF58DE3D96DBC32217EF3C70A5E781F7AC17F07F7C93B67461F5F1D56C5A93B7873FEC4F9752A3054A1910DDEC6FD33E4FFED073069F1014C8EF7018C1DCC3EEAD8B533A0EF2D61FD3192A2850533F46F7758CD1D3675F7FB991673B9750C62A5473B142BDD9FFD0A86E83671CB52945ED585BBE3D5DE8E73BF9AF31E357576344E83A3713A3F1AA78B7D73AABE22B1BE1384E2C71E49F1CB2CBCD426B3E00DAC44C165891F5F745FF288E1F6C142641D4471558311349528AC0AE5AA25A72B1932C9278BC032996A0D4C12D273185B01BF0E258D0D140AC1B6824F91711233A4F5B51616D87121AE9554E2C33BE2BAE82899CA3C5A51F4B02C1FBFD39B97AA7688A1E1F12B9C26E18431832C407A1BC473136EA8C705E67D6446024F1D9B766E5BDEE94A141EF32BF12B397AA686880983FF43E21DEB67193355EF0D9ED8C698B8393C2422E68BF81CC2A679422CE21584E9B163F9362B0BF555D461319BA50F5776474893F52C4ABADA1429C8D6F348D7B91422F46F49ADB22DB59C31A5244876929D5C28738FECC379D29BA7B9DB54D01EC661D26A338B91AEEE8E942927B35099E5372754CA9D308E33FBF0C06CDC6AEE8395D4A55E3891BC305764565A292CF9B64C142E7D3DF6D98EEF7B315336236861A74AF2C35D174161275F16C15A3394A47093A19217BBE3A5D559162C5D6D8CD42B44EAB540EA1722F55B209D15229DB5401A14220D5A209D17229DB740BA2844BA38FA0590CBC5E52D09F724279772EF619407D78FCA728971B8455550454B6A0649B1BEE602EC4EB0A1A37FB1C61685E0568C37DC1146E7C045D84D527BA7DD9E3468FB7A865E1AE7A6D56CF275F4CE180D945BDBFB6AD87BC90E98D89278C62BF1F2EDFC14B44D4BDDC427B18F967AA180831AF95A8C8FBE0DD3CAB39A7D9937379A4981738D9829336135527F57A6FC85D12F3E5C2ACFC842F92337C8F95FB85869F67A8CE1C8419C6C6B1EB2E1708069C8B7F33DA67387568EB6D398614FC8F254A1DEB8F5338542D1BADB5750AB91411970DB539F1D0A787028E0F343015FFC4BE066DDFD7C3FB651E77E97C67D98C862CC983978B450ECFC0060D7F67E7577BF8857763250D7B7CFF6F8AB2700459C5A8E08D6B503824266D28CA1E510215FA00CB5EC2FFE8613E074914204BFFF63E8A6986DA4A0F19E299B3BB157E351B312C55BE4E40604C164825C7982CE8921F0B5019C6FE65C9F89E507F6B367604ED9832F5C5F5C710EF6CCDA6AD60DB56AFE9B49C9B6CCC3073778E2FB38028A49CD4D7674ED53CB4CE4BE2908C72510C15718453E944A1741045CAC13A4FB5CC7B40C2852DF045C6041DC7C06DBB5108C3F309D2CA18D6C18F16E61418C755C679683D41B625BEDC309250B8FD83CC248E9F1117DD8B457EFFF01A0642532F82A0000 , N'6.2.0-61023')

