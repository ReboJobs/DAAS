let
    Source = Sql.Databases("@serverName"),
    @customerName = Source{[Name="@customerName"]}[Data],
    #"dbo_@viewName" = @customerName{[Schema="dbo",Item="@viewName"]}[Data]
in
    #"dbo_@viewName"