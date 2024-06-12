let
    Source = Sql.Databases("qtx-daaas-ondemand.sql.azuresynapse.net"),
    Qualiticks = Source{[Name="Qualiticks"]}[Data],
    #"dbo_Xero-Invoices" = Qualiticks{[Schema="dbo",Item="Xero-Invoices"]}[Data]
in
    #"dbo_Xero-Invoices"