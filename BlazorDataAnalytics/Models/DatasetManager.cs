using System;
using System.Text.RegularExpressions;
using Microsoft.AnalysisServices.Tabular;
using BlazorDataAnalytics.Models;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.PowerBI.Api.Models.Credentials;
using Microsoft.Rest;

namespace BlazorDataAnalytics.Models
{
    class DatasetManager
    {

        public static Server server = new Server();
        public static Server server2 = new Server();
        private Microsoft.Identity.Client.AuthenticationResult _accessToken;
        private string _profileId;

        // add static constructor to intialize connection
       
        public const string urlPowerBiServiceApiRoot = "https://api.powerbi.com/";

        public  DatasetManager(bool IsPowerBITemplate,string workspaceURl, Microsoft.Identity.Client.AuthenticationResult accessToken = null, string profileId = null)
        {
            this._accessToken = accessToken;
            this._profileId= profileId;
            string templateWorkspace = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? AppSettings.WorkspaceConnectionDevelopment : AppSettings.WorkspaceConnectionProduction;
            string conStringTemplate = $"Provider=MSOLAP;Data Source={templateWorkspace};User ID=app:8b29c164-355c-4ee0-96d5-5c8f927f0b04@94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0;Password=Z6r7Q~f3YHixLNTbUDZy4Y5SEEWrKeKykjmww;";
            try
            {
                if (IsPowerBITemplate)
                {
                    server.Disconnect();
                    server.Connect(conStringTemplate);
                }
                string workspaceCustomerConString = $"Provider=MSOLAP;Data Source={workspaceURl};User ID=app:8b29c164-355c-4ee0-96d5-5c8f927f0b04@94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0;Password=Z6r7Q~f3YHixLNTbUDZy4Y5SEEWrKeKykjmww;";
                server2.Disconnect();
                server2.Connect(workspaceCustomerConString);
                _profileId = profileId;
            }
            catch (Exception ex) {  }
        }

        public DatasetManager(Microsoft.Identity.Client.AuthenticationResult accessToken = null, string profileId = null)
        {
            this._accessToken = accessToken;
            _profileId = profileId;
        }
        public static Server ConnectToPowerBIAsServicePrincipal()
        {
            string workspaceConnection = "powerbi://api.powerbi.com/v1.0/myorg/DAaaS%20-%20Qualiticks";
            string tenantId = "94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0";
            string appId = "8b29c164-355c-4ee0-96d5-5c8f927f0b04";
            string appSecret = "Z6r7Q~f3YHixLNTbUDZy4Y5SEEWrKeKykjmww";
            string connectStringServicePrincipal = $"DataSource={workspaceConnection};User ID=app:{appId}@{tenantId};Password={appSecret};";
            server2.Connect(connectStringServicePrincipal);
            return server2;
        }
        public  Server getCustomerServer() {return server2;}
        public  Server getTemplateServer() { return server; }

        public static void ConnectToPowerTemplates()
        {
            string workspaceConnection = "powerbi://api.powerbi.com/v1.0/myorg/DAaaS%20-%20_Templates";
            string userId = "Joseph@qualiticks.com";
            string password = "ControlAltDelete!@#$%";
            string connectStringUser = $"DataSource={workspaceConnection};User ID={userId};Password={password};";
            server.Connect(connectStringUser);
        }
        public static Server ConnectToPowerBICustomerWorkspace()
        {
            string workspaceConnection = "powerbi://api.powerbi.com/v1.0/myorg/DAaaS%20-%20Qualiticks";
            string userId = "Joseph@qualiticks.com";
            string password = "ControlAltDelete!@#$%";
            string connectStringUser = $"DataSource={workspaceConnection};User ID={userId};Password={password};";
            server2.Connect(connectStringUser);
            return server2;
        }
        public static bool CheckServerStatus() {

            return server2.Connected;
          
        }
        public static Server Reconnect()
        {

             server2.Reconnect();
            return server2;

        }
        public bool CheckifColumnExistInTable(string DatasetName, string tableName)
        {
            bool isExist = false;
            try
            {
              var model=  server2.Databases.GetByName(DatasetName).Model;
                foreach(var tableItem in model.Tables)
                {
                    if (tableItem.Name.ToLower().Trim() == tableName.ToLower().Trim())
                    {
                        isExist = true;
                        break;
                    }
                }
             
            }
            catch (Exception ex) {
                isExist= false;
            }
            return isExist;
        }
        public static void Disconnect() {

            server.Disconnect(true);
            server2.Disconnect(true);
        }

        public static void DisplayDatabases()
        {
            foreach (Database database in server.Databases)
            {
                Console.WriteLine(database.Name);
                Console.WriteLine(database.CompatibilityLevel);
                Console.WriteLine(database.CompatibilityMode);
                Console.WriteLine(database.EstimatedSize);
                Console.WriteLine(database.ID);
                Console.WriteLine();
            }
        }

        public static void GetDatabaseInfo(string Name)
        {

            Database database = server.Databases.GetByName(Name);

            Console.WriteLine("Name: " + database.Name);

            Console.WriteLine("ID: " + database.ID);
            Console.WriteLine("ModelType: " + database.ModelType);
            Console.WriteLine("CompatibilityLevel: " + database.CompatibilityLevel);
            Console.WriteLine("LastUpdated: " + database.LastUpdate);
            Console.WriteLine("EstimatedSize: " + database.EstimatedSize);
            Console.WriteLine("CompatibilityMode: " + database.CompatibilityMode);
            Console.WriteLine("LastProcessed: " + database.LastProcessed);
            Console.WriteLine("LastSchemaUpdate: " + database.LastSchemaUpdate);

        }
        public Model GetAllTablesFromCustomerWorkspace(string DatabaseName)
        {
            try
            {               
             Database database = server2.Databases.GetByName(DatabaseName);
            Model model = database.Model;
            return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public Model GetAllTablesFromTemplateWorkspace(string DatabaseName)
        {
            try
            {
                Database database = server.Databases.GetByName(DatabaseName);
                Model model = database.Model;
                return model;
            }
            catch (Exception ex) {
                return null;
            }

        }
        public static void RefreshDatabaseModel(string Name)
        {
            Database database = server.Databases.GetByName(Name);
            database.Model.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.DataOnly);
            database.Model.SaveChanges();
        }

        public static Database CreateDatabase(string DatabaseName ,string description)
        {

            Console.WriteLine("Creating new dataset named " + DatabaseName);

            string newDatabaseName = server2.Databases.GetNewName(DatabaseName);

            var database = new Database()
            {
                Name = newDatabaseName,
                ID = newDatabaseName,
                CompatibilityLevel = 1520,
                StorageEngineUsed = Microsoft.AnalysisServices.StorageEngineUsed.TabularMetadata,
                Description = description,
                Model = new Model()
                {
                    Name = DatabaseName + "-Model",
                    Description = "A Tabular data model with 1520 compatibility level.",
                }
            };

            server2.Databases.Add(database);
            database.Update(Microsoft.AnalysisServices.UpdateOptions.ExpandFull);

            return database;
        }
        public static Microsoft.PowerBI.Api.Models.Group GetWorkspace(string Name)
        {
            PowerBIClient pbiClient = TokenManager.GetPowerBiClient(PowerBiPermissionScopes.ReadWorkspaces);
            // build search filter
            string filter = "name eq '" + Name + "'";
            var workspaces = pbiClient.Groups.GetGroups(filter: filter).Value;
            if (workspaces.Count == 0)
            {
                return null;
            }
            else
            {
                return workspaces.First();
            }
        }
        public  Microsoft.PowerBI.Api.Models.Dataset GetDataset(Guid WorkspaceId, string DatasetName, string profileId)
        {
            PowerBIClient pbiClient = string.IsNullOrEmpty(profileId) ? GetPowerBiClient() : GetPowerBiClientForProfile(new Guid(profileId));
            var datasets = pbiClient.Datasets.GetDatasetsInGroup(WorkspaceId).Value;
            foreach (var dataset in datasets)
            {
                if (dataset.Name.Equals(DatasetName))
                {
                    return dataset;
                }
            }
            return null;
        }
        public PowerBIClient GetPowerBiClient()
        {
            var tokenCredentials = new TokenCredentials(_accessToken.AccessToken, "Bearer");
            return new PowerBIClient(new Uri(urlPowerBiServiceApiRoot), tokenCredentials);
        }
        private PowerBIClient GetPowerBiClientForProfile(Guid ProfileId)
        {
            var uriPowerBiServiceApiRoot = new Uri(urlPowerBiServiceApiRoot);
            var tokenCredentials = new TokenCredentials(_accessToken.AccessToken, "Bearer");

            // create PowerBIClient for service principal profile
            return new PowerBIClient(uriPowerBiServiceApiRoot, tokenCredentials, ProfileId);
        }

        public Import ImportPBIX(Guid WorkspaceId, string PbixFilePath, string ImportName, string datasetID, string description, string profileId)
        {
           PowerBIClient pbiClient = string.IsNullOrEmpty(profileId) ? GetPowerBiClient() : GetPowerBiClientForProfile(new Guid(profileId));

            // open PBIX in file stream
            FileStream stream = new FileStream(PbixFilePath, FileMode.Open, FileAccess.Read);

                // post import to start import process
                var import = pbiClient.Imports.PostImportWithFileInGroup(WorkspaceId, stream, ImportName, ImportConflictHandlerMode.GenerateUniqueName);
                stream.Close();
                // poll to determine when import operation has complete
                do { import = pbiClient.Imports.GetImportInGroup(WorkspaceId, import.Id); }
                while (import.ImportState.Equals("Publishing"));
                RebindReportRequest request = new RebindReportRequest();
                request.DatasetId = datasetID;
            var oldDataset = import.Datasets.FirstOrDefault().Id;
                try
                {
                   pbiClient.Reports.RebindReport(WorkspaceId, import.Reports.FirstOrDefault().Id, request);
                   pbiClient.Datasets.RefreshDataset(WorkspaceId, datasetID);
                   pbiClient.Datasets.DeleteDatasetInGroup(WorkspaceId, oldDataset);
                }
                catch (Exception ex) { }
                // return Import object to caller
                return import;

        }
        public void RefreshDataset(Guid WorkspaceId, string DatasetId, string profileId) 
        {
            PowerBIClient pbiClient = string.IsNullOrEmpty(profileId) ? GetPowerBiClient() : GetPowerBiClientForProfile(new Guid(profileId));
            var dataset = (pbiClient.Datasets.RefreshDataset(WorkspaceId, DatasetId));

        }
         public void PatchSqlDatasourceCredentials(Guid WorkspaceId, string DatasetId, string SqlUserName, string SqlUserPassword, string profileId, string server)
        {
            PowerBIClient pbiClient =  GetPowerBiClient();

            var datasources = (pbiClient.Datasets.GetDatasourcesInGroup(WorkspaceId, DatasetId)).Value;
            pbiClient.Datasets.TakeOver(WorkspaceId, DatasetId);
            

            // find the target SQL datasource
            foreach (var datasource in datasources)
            {
                if (datasource !=null &&  (datasource.ConnectionDetails.Server !=String.Empty || datasource.ConnectionDetails.Server !=null))
                {
                    if (datasource.DatasourceType.ToLower() == "sql")
                    {
                        // get the datasourceId and the gatewayId
                        var datasourceId = datasource.DatasourceId;
                        var gatewayId = datasource.GatewayId;
                        // Create UpdateDatasourceRequest to update Azure SQL datasource credentials
                        UpdateDatasourceRequest req = new UpdateDatasourceRequest
                        {
                            CredentialDetails = new CredentialDetails(
                            new BasicCredentials(SqlUserName, SqlUserPassword),
                            PrivacyLevel.None,
                            EncryptedConnection.NotEncrypted)
                        };
                        // Execute Patch command to update Azure SQL datasource credentials
                        pbiClient.Gateways.UpdateDatasource((Guid)gatewayId, (Guid)datasourceId, req);
                    }
                }
                
            }

        }
        public void PatchSqlDatasourceCredentials(Guid WorkspaceId, string DatasetId,string server,string databaseName, string SqlUserName, string SqlUserPassword, string profileId)
        {
            PowerBIClient pbiClient =  GetPowerBiClient();

            var datasources = (pbiClient.Datasets.GetDatasourcesInGroup(WorkspaceId, DatasetId)).Value;
            pbiClient.Datasets.TakeOver(WorkspaceId, DatasetId);
            // find the target SQL datasource
            foreach (var datasource in datasources)
            {
                    if (datasource.DatasourceType.ToLower() == "sql")
                    {
                        // get the datasourceId and the gatewayId
                        var datasourceId = datasource.DatasourceId;
                        var gatewayId = datasource.GatewayId;
                    UpdateDatasourcesRequest updateServer = new UpdateDatasourcesRequest();
                    UpdateDatasourceConnectionRequest connectionRequest = new UpdateDatasourceConnectionRequest();
                    connectionRequest.ConnectionDetails.Server = server;
                    connectionRequest.ConnectionDetails.Database = databaseName;
                    updateServer.UpdateDetails.Add(connectionRequest);
                    pbiClient.Datasets.UpdateDatasourcesInGroup(WorkspaceId, DatasetId, updateServer);
                    // Create UpdateDatasourceRequest to update Azure SQL datasource credentials
                    UpdateDatasourceRequest req = new UpdateDatasourceRequest
                        {
                            CredentialDetails = new CredentialDetails(
                            new BasicCredentials(SqlUserName, SqlUserPassword),
                            PrivacyLevel.None,
                            EncryptedConnection.NotEncrypted)
                        };
                        // Execute Patch command to update Azure SQL datasource credentials
                        pbiClient.Gateways.UpdateDatasource((Guid)gatewayId, (Guid)datasourceId, req);
                    }               
               

            }

        }
        public static Database CreateDatabaseToCustomerWorkspace(string DatabaseName)
        {

            string newDatabaseName = server2.Databases.GetNewName(DatabaseName);

            var database = new Database()
            {
                Name = newDatabaseName,
                ID = newDatabaseName,
                CompatibilityLevel = 1540,
                StorageEngineUsed = Microsoft.AnalysisServices.StorageEngineUsed.TabularMetadata,
                ReadWriteMode = Microsoft.AnalysisServices.ReadWriteMode.ReadWrite,
                Model = new Model()
                {
                    Name = DatabaseName + "-Model",
                    Description = "A Demo Tabular data model with 1520 compatibility level."
                }
            };

            server2.Databases.Add(database);
            database.Update(Microsoft.AnalysisServices.UpdateOptions.ExpandFull);

            return database;
        }


        public static Database CopyDatabase(string sourceDatabaseName, string DatabaseName)
        {

            Database sourceDatabase = server.Databases.GetByName(sourceDatabaseName);

            string newDatabaseName = server.Databases.GetNewName(DatabaseName);
            Database targetDatabase = CreateDatabase(newDatabaseName, sourceDatabase.Description);
            sourceDatabase.Model.CopyTo(targetDatabase.Model);
            sourceDatabase.Model.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.Full);
            targetDatabase.Model.SaveChanges();

            //targetDatabase.Model.RequestRefresh(RefreshType.Full);
            //targetDatabase.Model.SaveChanges();

            return targetDatabase;
        }

        public async static Task<Database> CopyDatabaseToOtherWorkspace(string sourceDatabaseName, string DatabaseName)
        {

            Database sourceDatabase = server.Databases.GetByName(sourceDatabaseName);

            string newDatabaseName = server.Databases.GetNewName(DatabaseName);
            Database targetDatabase = CreateDatabaseToCustomerWorkspace(newDatabaseName);
            sourceDatabase.Model.CopyTo(targetDatabase.Model);
           sourceDatabase.Model.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.Full);
            targetDatabase.Model.SaveChanges();
            try
            {
                targetDatabase.Model.RequestRefresh(Microsoft.AnalysisServices.Tabular.RefreshType.DataOnly);
                targetDatabase.Model.SaveChanges();
            }
            catch (Exception ex) { }

            return targetDatabase;
        }



    }
}
