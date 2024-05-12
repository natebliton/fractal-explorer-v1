using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class DestinationList
{
    public enum Worlds {
        NULL,
        // island 1
        AtmosphereStorms,
        BeachBall,
        BlueStage,
        BubbleLands,
        CoralBright,
        CoralWithGiantClam,
        DragonCave,
        EmeraldCave,
        FlowerGenerator,
        GardenBridge,
        GoldWaterCaveStage,
        GreenPlanets,
        LawnStage,
        SandDollars, // not done yet!
        TreeForOwls,
        WaterCave,
        // island 2
        AlienBase,
        CavernFlowerPillar,
        CoralAndUfos,
        FlowerStarDragon,
        ForestStage,
        GardenAndSwirls,
        GardenGlass,
        GardenHome,
        GardenPeach,
        GardenPurple,
        GardenTower,
        GoldAndPurpleStage,
        JungleRiver,
        LandingPlatforms,
        OceanHouse,
        PlanetsAndStars,
        PlanetsNebulaTunnel,
        WaterAndEarth,
        WaterCaveStage,
        // island 3
        BubbleStage,
        CDGarden,
        Dawn,
        GalaxyLarge,
        GardenBlueWall,
        GardenRedAndPurple,
        HurricaneGarden,
        Levitation,
        OceanSphere,
        PeachAndGoldStage,
        Pink,
        PlanetsWithRings,
        SeaMonsterNursery,
        SevenSidesStage,
        SpaceGardening,
        // island 4
        BlueLandscape,
        GardenFountain,
        GardenSparkle,
        Volcano, // MoonDeer
        RedRoom,
        RoundPalmStage,
        RubyCavern,
        SandstormPlanets,
        SpacePort,
        SparklePalms,
        StageNeon,
        ToothyWaterStage,
        WorldSpirals,
        YellowLandscape,
        // Island 5
        AirDragonAndCity,
        BatCavern,
        CoralDrumKit,
        DeepWaterRuin,
        FenceAndFlowers,
        GardenBuds,
        GardenStage,
        HeartNebula,
        MachinePortal,
        NightFlowerbed, // midnight flowerbed
        Pink4,
        PlanetsPinkAndGreen,
        PlanetSurface,
        ShellStage,
        SmallFort,
        SpaceHighway,
        SparklePond,
        Stairs4Stage,
        StarryNight
        // extra, unused for now
        //  GardenRopes,


    }

    public enum Islands {
        NULL,
        Island1,
        Island2,
        Island3,
        Island4,
        Island5,
        Island6
    }

    public static readonly Dictionary<Worlds, bool> WorldReady = new Dictionary<Worlds, bool>() {
        { Worlds.NULL, false },
        // island 1
        { Worlds.AtmosphereStorms, true },
        { Worlds.BeachBall, true },
        { Worlds.BlueStage, true },
        { Worlds.BubbleLands, true },
        { Worlds.CoralBright, true },
        { Worlds.CoralWithGiantClam, true },
        { Worlds.DragonCave, true },
        { Worlds.EmeraldCave, true },
        { Worlds.FlowerGenerator, true },
        { Worlds.GardenBridge, true },
        { Worlds.GoldWaterCaveStage, true },
        { Worlds.GreenPlanets, true },
        { Worlds.LawnStage, true },
        { Worlds.SandDollars, false }, // not done yet!
        { Worlds.TreeForOwls, true },
        { Worlds.WaterCave, true },
        // island 2
        { Worlds.AlienBase, false },
        { Worlds.CavernFlowerPillar, false },
        { Worlds.CoralAndUfos, false },
        { Worlds.FlowerStarDragon, false },
        { Worlds.ForestStage, false },
        { Worlds.GardenAndSwirls, false },
        { Worlds.GardenGlass, false },
        { Worlds.GardenHome, false },
        { Worlds.GardenPeach, false },
        { Worlds.GardenPurple, false },
        { Worlds.GardenTower, false },
        { Worlds.GoldAndPurpleStage, false },
        { Worlds.JungleRiver, false },
        { Worlds.LandingPlatforms, false },
        { Worlds.OceanHouse, false },
        { Worlds.PlanetsAndStars, false },
        { Worlds.PlanetsNebulaTunnel, false },
        { Worlds.WaterAndEarth, false },
        { Worlds.WaterCaveStage, false },
        // island 3
        { Worlds.BubbleStage, false },
        { Worlds.CDGarden, false },
        { Worlds.Dawn, false },
        { Worlds.GalaxyLarge, false },
        { Worlds.GardenBlueWall, false },
        { Worlds.GardenRedAndPurple, false },
        { Worlds.HurricaneGarden, false },
        { Worlds.Levitation, false },
        { Worlds.OceanSphere, false },
        { Worlds.PeachAndGoldStage, false },
        { Worlds.Pink, false },
        { Worlds.PlanetsWithRings, false },
        { Worlds.SeaMonsterNursery, false },
        { Worlds.SevenSidesStage, false },
        { Worlds.SpaceGardening, false },
        // island 4
        { Worlds.BlueLandscape, false },
        { Worlds.GardenFountain, false },
        { Worlds.GardenSparkle, false },
        { Worlds.Volcano, false }, // MoonDeer
        { Worlds.RedRoom, false },
        { Worlds.RoundPalmStage, false },
        { Worlds.RubyCavern, false },
        { Worlds.SandstormPlanets, false },
        { Worlds.SpacePort, false },
        { Worlds.SparklePalms, false },
        { Worlds.StageNeon, false },
        { Worlds.ToothyWaterStage, false },
        { Worlds.WorldSpirals, false },
        { Worlds.YellowLandscape, false },
        // Island 5
        { Worlds.AirDragonAndCity, false },
        { Worlds.BatCavern, false },
        { Worlds.CoralDrumKit, false },
        { Worlds.DeepWaterRuin, false },
        { Worlds.FenceAndFlowers, false },
        { Worlds.GardenBuds, false },
        { Worlds.GardenStage, false },
        { Worlds.HeartNebula, false },
        { Worlds.MachinePortal, false },
        { Worlds.NightFlowerbed, false }, // midnight flowerbed
        { Worlds.Pink4, false },
        { Worlds.PlanetsPinkAndGreen, false },
        { Worlds.PlanetSurface, false },
        { Worlds.ShellStage, false },
        { Worlds.SmallFort, false },
        { Worlds.SpaceHighway, false },
        { Worlds.SparklePond, false },
        { Worlds.Stairs4Stage, false },
        { Worlds.StarryNight, false }
    };
        

    public static readonly Dictionary<Worlds, Islands> WorldParentIsland = new Dictionary<Worlds, Islands>(){
        { Worlds.AtmosphereStorms, Islands.Island1 },
        { Worlds.BeachBall, Islands.Island1 },
        { Worlds.BlueStage, Islands.Island1 },
        { Worlds.BubbleLands, Islands.Island1 },
        { Worlds.CoralBright, Islands.Island1 },
        { Worlds.CoralWithGiantClam, Islands.Island1 },
        { Worlds.DragonCave, Islands.Island1 },
        { Worlds.EmeraldCave, Islands.Island1 },
        { Worlds.FlowerGenerator, Islands.Island1 },
        { Worlds.GardenBridge, Islands.Island1 },
        { Worlds.GoldWaterCaveStage, Islands.Island1 },
        { Worlds.GreenPlanets, Islands.Island1 },
        { Worlds.LawnStage, Islands.Island1 },
        { Worlds.SandDollars, Islands.Island1 },
        { Worlds.TreeForOwls, Islands.Island1 },
        { Worlds.WaterCave, Islands.Island1 }
    };

}
