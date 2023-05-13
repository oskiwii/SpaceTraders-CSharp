using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace spacetraders.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SystemType
    {
        NEUTRON_STAR,
        RED_STAR,
        ORANGE_STAR,
        BLUE_STAR,
        YOUNG_STAR,
        WHITE_DWARF,
        BLACK_HOLE,
        HYPERGIANT,
        NEBULA,
        UNSTABLE
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContractType
    {
        PROCUREMENT,
        TRANSPORT,
        SHUTTLE
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        PURCHASE,
        SELL
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RotationType
    {
        STRICT,
        RELAXED
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaypointType
    {
        PLANET,
        GAS_GIANT,
        MOON,
        ORBITAL_STATION,
        JUMP_GATE,
        ASTEROID_FIELD,
        NEBULA,
        DEBRIS_FIELD,
        GRAVITY_WELL
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TradeGoodSupply
    {
        SCARCE,
        LIMITED,
        MODERATE,
        ABUNDANT
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EngineSymbol
    {
        ENGINE_IMPULSE_DRIVE_I,
        ENGINE_ION_DRIVE_I,
        ENGINE_ION_DRIVE_II,
        ENGINE_HYPER_DRIVE_I
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FrameSymbol
    {
        FRAME_PROBE,
        FRAME_DRONE,
        FRAME_INTERCEPTOR,
        FRAME_RACER,
        FRAME_FIGHTER,
        FRAME_FRIGATE,
        FRAME_SHUTTLE,
        FRAME_EXPLORER,
        FRAME_MINER,
        FRAME_LIGHT_FREIGHTER,
        FRAME_HEAVY_FREIGHTER,
        FRAME_TRANSPORT,
        FRAME_DESTROYER,
        FRAME_CRUISER,
        FRAME_CARRIER
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipModuleSymbol
    {
        MODULE_MINERAL_PROCESSOR_I,
        MODULE_CARGO_HOLD_I,
        MODULE_CREW_QUARTERS_I,
        MODULE_ENVOY_QUARTERS_I,
        MODULE_PASSENGER_CABIN_I,
        MODULE_MICRO_REFINERY_I,
        MODULE_ORE_REFINERY_I,
        MODULE_FUEL_REFINERY_I,
        MODULE_SCIENCE_LAB_I,
        MODULE_JUMP_DRIVE_I,
        MODULE_JUMP_DRIVE_II,
        MODULE_JUMP_DRIVE_III,
        MODULE_WARP_DRIVE_I,
        MODULE_WARP_DRIVE_II,
        MODULE_WARP_DRIVE_III,
        MODULE_SHIELD_GENERATOR_I,
        MODULE_SHIELD_GENERATOR_II
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MountSymbol
    {
        MOUNT_GAS_SIPHON_I,
        MOUNT_GAS_SIPHON_II,
        MOUNT_GAS_SIPHON_III,
        MOUNT_SURVEYOR_I,
        MOUNT_SURVEYOR_II,
        MOUNT_SURVEYOR_III,
        MOUNT_SENSOR_ARRAY_I,
        MOUNT_SENSOR_ARRAY_II,
        MOUNT_SENSOR_ARRAY_III,
        MOUNT_MINING_LASER_I,
        MOUNT_MINING_LASER_II,
        MOUNT_MINING_LASER_III,
        MOUNT_LASER_CANNON_I,
        MOUNT_MISSILE_LAUNCHER_I,
        MOUNT_TURRET_I
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DepositType
    {
        QUARTZ_SAND,
        SILICON_CRYSTALS,
        PRECIOUS_STONES,
        ICE_WATER,
        AMMONIA_ICE,
        IRON_ORE,
        COPPER_ORE,
        SILVER_ORE,
        ALUMINUM_ORE,
        GOLD_ORE,
        PLATINUM_ORE,
        DIAMONDS,
        URANITE_ORE,
        MERITIUM_ORE
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipStatus
    {
        IN_TRANSIT,
        IN_ORBIT,
        DOCKED
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FlightMode
    {
        DRIFT,
        STEALTH,
        CRUISE,
        BURN
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReactorSymbol
    {
        REACTOR_SOLAR_I,
        REACTOR_FUSION_I,
        REACTOR_FISSION_I,
        REACTOR_CHEMICAL_I,
        REACTOR_ANTIMATTER_I
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipRole
    {
        FABRICATOR,
        HARVESTER,
        HAULER,
        INTERCEPTOR,
        EXCAVATOR,
        TRANSPORT,
        REPAIR,
        SURVEYOR,
        COMMAND,
        CARRIER,
        PATROL,
        SATELLITE,
        EXPLORER,
        REFINERY
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipType
    {
        SHIP_PROBE,
        SHIP_MINING_DRONE,
        SHIP_INTERCEPTOR,
        SHIP_LIGHT_HAULER,
        SHIP_COMMAND_FRIGATE,
        SHIP_EXPLORER,
        SHIP_HEAVY_FREIGHTER,
        SHIP_LIGHT_SHUTTLE,
        SHIP_ORE_HOUND,
        SHIP_REFINING_FREIGHTER
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SurveySize
    {
        SMALL,
        MODERATE,
        LARGE
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TradeSymbol
    {
        PRECIOUS_STONES,
        QUARTZ_SAND,
        SILICON_CRYSTALS,
        AMMONIA_ICE,
        LIQUID_HYDROGEN,
        LIQUID_NITROGEN,
        ICE_WATER,
        EXOTIC_MATTER,
        ADVANCED_CIRCUITRY,
        GRAVITON_EMITTERS,
        IRON,
        IRON_ORE,
        COPPER,
        COPPER_ORE,
        ALUMINUM,
        ALUMINUM_ORE,
        SILVER,
        SILVER_ORE,
        GOLD,
        GOLD_ORE,
        PLATINUM,
        PLATINUM_ORE,
        DIAMONDS,
        URANITE,
        URANITE_ORE,
        MERITIUM,
        MERITIUM_ORE,
        HYDROCARBON,
        ANTIMATTER,
        FERTILIZERS,
        FABRICS,
        FOOD,
        JEWELRY,
        MACHINERY,
        FIREARMS,
        ASSAULT_RIFLES,
        MILITARY_EQUIPMENT,
        EXPLOSIVES,
        LAB_INSTRUMENTS,
        AMMUNITION,
        ELECTRONICS,
        SHIP_PLATING,
        EQUIPMENT,
        FUEL,
        MEDICINE,
        DRUGS,
        CLOTHING,
        MICROPROCESSORS,
        PLASTICS,
        POLYNUCLEOTIDES,
        BIOCOMPOSITES,
        NANOBOTS,
        AI_MAINFRAMES,
        QUANTUM_DRIVES,
        ROBOTIC_DRONES,
        CYBER_IMPLANTS,
        GENE_THERAPEUTICS,
        NEURAL_CHIPS,
        MOOD_REGULATORS,
        VIRAL_AGENTS,
        MICRO_FUSION_GENERATORS,
        SUPERGRAINS,
        LASER_RIFLES,
        HOLOGRAPHICS,
        SHIP_SALVAGE,
        RELIC_TECH,
        NOVEL_LIFEFORMS,
        BOTANICAL_SPECIMENS,
        CULTURAL_ARTIFACTS,
        REACTOR_SOLAR_I,
        REACTOR_FUSION_I,
        REACTOR_FISSION_I,
        REACTOR_CHEMICAL_I,
        REACTOR_ANTIMATTER_I,
        ENGINE_IMPULSE_DRIVE_I,
        ENGINE_ION_DRIVE_I,
        ENGINE_ION_DRIVE_II,
        ENGINE_HYPER_DRIVE_I,
        MODULE_MINERAL_PROCESSOR_I,
        MODULE_CARGO_HOLD_I,
        MODULE_CREW_QUARTERS_I,
        MODULE_ENVOY_QUARTERS_I,
        MODULE_PASSENGER_CABIN_I,
        MODULE_MICRO_REFINERY_I,
        MODULE_ORE_REFINERY_I,
        MODULE_FUEL_REFINERY_I,
        MODULE_SCIENCE_LAB_I,
        MODULE_JUMP_DRIVE_I,
        MODULE_JUMP_DRIVE_II,
        MODULE_JUMP_DRIVE_III,
        MODULE_WARP_DRIVE_I,
        MODULE_WARP_DRIVE_II,
        MODULE_WARP_DRIVE_III,
        MODULE_SHIELD_GENERATOR_I,
        MODULE_SHIELD_GENERATOR_II,
        MOUNT_GAS_SIPHON_I,
        MOUNT_GAS_SIPHON_II,
        MOUNT_GAS_SIPHON_III,
        MOUNT_SURVEYOR_I,
        MOUNT_SURVEYOR_II,
        MOUNT_SURVEYOR_III,
        MOUNT_SENSOR_ARRAY_I,
        MOUNT_SENSOR_ARRAY_II,
        MOUNT_SENSOR_ARRAY_III,
        MOUNT_MINING_LASER_I,
        MOUNT_MINING_LASER_II,
        MOUNT_MINING_LASER_III,
        MOUNT_LASER_CANNON_I,
        MOUNT_MISSILE_LAUNCHER_I,
        MOUNT_TURRET_I
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaypointTraitSymbol
    {
        UNCHARTED,
        MARKETPLACE,
        SHIPYARD,
        OUTPOST,
        SCATTERED_SETTLEMENTS,
        SPRAWLING_CITIES,
        MEGA_STRUCTURES,
        OVERCROWDED,
        HIGH_TECH,
        CORRUPT,
        BUREAUCRATIC,
        TRADING_HUB,
        INDUSTRIAL,
        BLACK_MARKET,
        RESEARCH_FACILITY,
        MILITARY_BASE,
        SURVEILLANCE_OUTPOST,
        EXPLORATION_OUTPOST,
        MINERAL_DEPOSITS,
        COMMON_METAL_DEPOSITS,
        PRECIOUS_METAL_DEPOSITS,
        RARE_METAL_DEPOSITS,
        METHANE_POOLS,
        ICE_CRYSTALS,
        EXPLOSIVE_GASES,
        STRONG_MAGNETOSPHERE,
        VIBRANT_AURORAS,
        SALT_FLATS,
        CANYONS,
        PERPETUAL_DAYLIGHT,
        PERPETUAL_OVERCAST,
        DRY_SEABEDS,
        MAGMA_SEAS,
        SUPERVOLCANOES,
        ASH_CLOUDS,
        VAST_RUINS,
        MUTATED_FLORA,
        TERRAFORMED,
        EXTREME_TEMPERATURES,
        EXTREME_PRESSURE,
        DIVERSE_LIFE,
        SCARCE_LIFE,
        FOSSILS,
        WEAK_GRAVITY,
        STRONG_GRAVITY,
        CRUSHING_GRAVITY,
        TOXIC_ATMOSPHERE,
        CORROSIVE_ATMOSPHERE,
        BREATHABLE_ATMOSPHERE,
        JOVIAN,
        ROCKY,
        VOLCANIC,
        FROZEN,
        SWAMP,
        BARREN,
        TEMPERATE,
        JUNGLE,
        OCEAN,
        STRIPPED
    }
}