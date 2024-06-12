let
    Source = Sql.Databases("qtx-daaas-ondemand.sql.azuresynapse.net"),
    Qualiticks = Source{[Name="Qualiticks"]}[Data],
    #"dbo_Xero-Accounts" = Qualiticks{[Schema="dbo",Item="Xero-Accounts"]}[Data]
in
    #"dbo_Xero-Accounts"