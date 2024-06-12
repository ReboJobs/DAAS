let
    Source = Sql.Databases("qtx-daaas-ondemand.sql.azuresynapse.net"),
    Qualiticks = Source{[Name="Qualiticks"]}[Data],
    #"dbo_Xero-Contacts" = Qualiticks{[Schema="dbo",Item="Xero-Contacts"]}[Data]
in
    #"dbo_Xero-Contacts"