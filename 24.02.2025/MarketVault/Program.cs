using MarketVault;

DbManager dbManager = new();;

CommandManager commandManager = new(dbManager);

commandManager.StartApp();