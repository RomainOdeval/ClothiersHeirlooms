using System;
using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using ClothierHeirloomsmod.NSBlock;
using ClothierHeirloomsmod.NSBlockEntity;

namespace ClothierHeirloomsmod
{
    public class ClothierHeirloomsmodModSystem : ModSystem
    {
        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterBlockClass("BlockSpinner", typeof(BlockSpinner));
            api.RegisterBlockClass("BlockAutoloom", typeof(BlockAutoloom));

            api.RegisterBlockEntityClass("Spinner", typeof(BlockEntitySpinner));
            api.RegisterBlockEntityClass("Autoloom", typeof(BlockEntityAutoloom));
        }


        //config stuff
        private ICoreServerAPI sapi;
        public static ClothierHeirloomsConfig Config { get; private set; }

        public class ClothierHeirloomsConfig {
            public int LoomInput = 3;
            public int LoomOutput = 2;
            public int SpinnerInput = 3;
            public int SpinnerOutput = 2;
        }


        public override void StartServerSide(ICoreServerAPI api)
        {
            base.StartServerSide(api);
            sapi = api;

            try
            {
                Config = sapi.LoadModConfig<ClothierHeirloomsConfig>("ClothierHeirloomsConfig.json");
                if (Config == null)
                {
                    Config = new ClothierHeirloomsConfig(); // use defaults
                    sapi.StoreModConfig(Config, "ClothierHeirloomsConfig.json");
                }
            }
            catch (System.Exception e)
            {
                sapi.Logger.Error("[ClothierHeirloomsConfig] Error loading config, using defaults: {0}", e);
                Config = new ClothierHeirloomsConfig();
            }

            sapi.Logger.Notification(
                $"[ClothierHeirloomsConfig] Config loaded: LoomInput={Config.LoomInput}, LoomOutput={Config.LoomOutput}, SpinnerInput={Config.SpinnerInput}, SpinnerSpinnerOutput={Config.SpinnerOutput}"
            );

        }


    }
}


