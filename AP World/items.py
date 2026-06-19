from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import Item, ItemClassification

if TYPE_CHECKING:
    from .world import FantasticFistWorld

ITEM_NAME_TO_ID = {
    "Destructible Blocks": 1,
    "Progressive Destructible Blocks": 2,
    "Smash Blocks": 3,
    "Burnable Blocks": 4,
    "Snake Blocks": 5,

    "Physics Blocks": 10,
    "Progressive Physics Blocks": 11,
    "Standard Physics Blocks": 12,
    "Ice Blocks": 13,
    "Yellow Physics Blocks": 14,
    "Concrete Blocks": 15,
    "Electric Blocks": 16,
    "Line Blocks": 17,

    "Sliding Blocks": 20,
    "Progressive Sliding Blocks": 21,
    "Standard Sliding Blocks": 22,
    "Yellow Sliding Blocks": 23,
    "Blue Sliding Blocks": 24,
    "Crystal Sliding Blocks": 25,
    "Galactic Sliding Blocks": 26,

    "Boss Blocks": 30,
    "Progressive Boss Blocks": 31,
    "Standard Star Blocks": 32,
    "Yellow Star Blocks": 33,
    "Blue Star Blocks": 34,
    "Standard Heart Blocks": 35,
    "Sliding Heart Blocks": 36,
    "Delayed Heart Blocks": 37,

    "Pop Blocks": 40,
    "Progressive Pop Blocks": 41,
    "Standard Pop Blocks": 42,
    "Galactic Pop Blocks": 43,

    "Bumpers": 50,
    "Progressive Bumpers": 51,
    "Standard Bumpers": 52,
    "Directional Bumpers": 53,
    "Yellow Bumpers": 54,
    "Black Hole Bumpers": 55,

    "Switches": 60,
    "Progressive Switches": 61,
    "Blue Switches": 62,
    "Orange Switches": 63,

    "Punchappear Blocks": 70,
    "Progressive Punchappear Blocks": 71,
    "Standard Punchappear Blocks": 72,
    "Yellow Punchappear Blocks": 73,
    "Blue Punchappear Blocks": 74,
    "Orange Punchappear Blocks": 75,

    "Skull Blocks": 80,
    "Progressive Skull Blocks": 81,
    "Yellow Skull Blocks": 82,
    "Blue Skull Blocks": 83,
    "Orange Skull Blocks": 84,

    "Skull Rings": 90,
    "Progressive Skull Rings": 91,
    "Yellow Skull Rings": 92,
    "Blue Skull Rings": 93,

    "Enemies": 100,
    "Progressive Enemies": 101,
    "Gubes": 102,
    "Yellow Gorbs": 103,
    "Blue Gorbs": 104,
    "Pixies": 105,

    "Vivi Blocks": 110,
    "Progressive Vivi Blocks": 111,
    "Standard Vivi Blocks": 112,
    "Yellow Vivi Blocks": 113,
    "Firework Vivi Blocks": 114,

    "Block Launchers": 120,
    "Progressive Block Launchers": 121,
    "Standard Block Launchers": 122,
    "Wing Block Launchers": 123,
    "Pearl Block Launchers": 124,
    "Ice Block Launchers": 125,
    "Yellow Block Launchers": 126,
    "Blue Block Launchers": 127,
    "Inverted Block Launchers": 128,
    "Galactic Block Launchers": 129,
    "Fire Block Launchers": 130,

    "Launchers": 140,
    "Progressive Launchers": 141,
    "Standard Launchers": 142,
    "Blue Pearl Launchers": 143,
    "Red Pearl Launchers": 144,
    "Yellow Crystal Launchers": 145,
    "Blue Crystal Launchers": 146,
    "Moon Launchers": 147,

    "Hazards": 150,
    "Progressive Hazards": 151,
    "Standard Spinners": 152,
    "Star Spinners": 153,
    "Red Fire Rings": 154,
    "Blue Fire Rings": 155,

    "Bubbles": 160,
    "Progressive Bubbles": 161,
    "Green Bubbles": 162,
    "Key Bubbles": 163,
    "Number Bubbles": 164,
    "Clear Bubbles": 165,
    "Honey Bubbles": 166,

    "Balloons": 170,
    "Progressive Balloons": 171,
    "Red Balloons": 172,
    "Blue Balloons": 173,
    "Lead Balloons": 174,
    "Toggle Balloons": 175,

    "Bombs": 180,
    "Progressive Bombs": 181,
    "Bomb Flowers": 182,
    "Bomb Blocks": 183,
    "Hive Bombs": 184,

    "Hive Blocks": 190,
    "Progressive Hive Blocks": 191,
    "Blue Hive Blocks": 192,
    "Red Hive Blocks": 193,

    "Keys": 200,
    "Progressive Keys": 201,
    "Standard Key Blocks": 202,
    "Key Quartets": 203,
    "Ice Key Blocks": 204,
    "Inverted Key Blocks": 205,

    "Gravity Items": 210,
    "Progressive Gravity Items": 211,
    "Up Gravity Flippers": 212,
    "Down Gravity Flippers": 213,
    "Up Gravity Fields": 214,
    "Down Gravity Fields": 215,
    "Up Water": 216,
    "Down Water": 217,
    "Gravity Fists": 218,
    "Gravity Anchors": 219,

    "Lifts": 220,
    "Progressive Lifts": 221,
    "Arrow Lifts": 222,
    "Yellow Lifts": 223,
    "Hive Lifts": 224,

    "Semisolids": 230,
    "Progressive Semisolids": 231,
    "Standard Semisolids": 232,
    "Inverted Semisolids": 233,
    "Toggle Semisolids": 234,

    "On Off Blocks": 240,
    "Timer Buttons": 241,
    "Toggle Flowers": 242,
    "Tethers": 243,
    "Icicles": 244,
    "Glass Blocks": 245,
    "Vivi's Flashlight": 246,
    "Thermals": 247,
    "Golf Ball": 248,
    "Golf Cart": 249,
    "Falling Crystals": 250,
    "Grab Blocks": 251,
    "Mirrors": 252,
    "Barrels": 253,
    "Pillars": 254,
    "Yellow Spin Blocks": 255,
    "Trees": 256,

    "Coin": 260,

    "Progressive Standard Path": 300,
    "Progressive Secret Path": 301,

    "1-1 Standard Exit Path": 310,
    "1-2 Standard Exit Path": 311,
    "1-3 Standard Exit Path": 312,
    "1-4 Standard Exit Path": 313,
    "1-5 Standard Exit Path": 314,
    "1-6 Standard Exit Path": 315,
    "1-7 Standard Exit Path": 316,
    "2-1 Standard Exit Path": 317,
    "2-2 Standard Exit Path": 318,
    "2-3 Standard Exit Path": 319,
    "2-4 Standard Exit Path": 320,
    "2-5 Standard Exit Path": 321,
    "3-1 Standard Exit Path": 322,
    "3-2 Standard Exit Path": 323,
    "3-3 Standard Exit Path": 324,
    "3-4 Standard Exit Path": 325,
    "3-5 Standard Exit Path": 326,
    "3-6 Standard Exit Path": 327,
    "4-1 Standard Exit Path": 328,
    "4-2 Standard Exit Path": 329,
    "4-3 Standard Exit Path": 330,
    "4-4 Standard Exit Path": 331,
    "4-5 Standard Exit Path": 332,
    "4-6 Standard Exit Path": 333,
    "4-7 Standard Exit Path": 334,
    "4-8 Standard Exit Path": 335,
    "5-1 Standard Exit Path": 336,
    "5-2 Standard Exit Path": 337,
    "5-3 Standard Exit Path": 338,
    
    "1-2 Secret Exit Path": 340,
    "1-4 Secret Exit Path": 341,
    "2-1 Secret Exit Path": 342,
    "2-C Secret Exit Path": 343,
    "3-1 Secret Exit Path": 344,
    "4-1 Secret Exit Path": 345,
    
    "1-A Standard Exit Path": 346,
    "1-B Standard Exit Path": 347,
    "1-C Standard Exit Path": 348,
    "2-A Standard Exit Path": 349,
    "2-B Standard Exit Path": 350,
    "2-C Standard Exit Path": 351,
    "3-A Standard Exit Path": 352,
    "3-B Standard Exit Path": 353,
    "4-A Standard Exit Path": 354,
    
    "1-8 Boss Exit Path": 360,
    "2-6 Boss Exit Path": 361,
    "3-7 Boss Exit Path": 362,
    "4-9 Boss Exit Path": 363,
    
    "2-D Standard Exit Path": 364,
    
    "1-1 Home Exit Path": 370,

    "Nothing": 400
}

ID_TO_ITEM_NAME = {v: k for k, v in ITEM_NAME_TO_ID.items()}

DEFAULT_ITEM_CLASSIFICATIONS = {
    "Destructible Blocks": ItemClassification.progression,
    "Progressive Destructible Blocks": ItemClassification.progression,
    "Smash Blocks": ItemClassification.progression,
    "Burnable Blocks": ItemClassification.progression,
    "Snake Blocks": ItemClassification.progression,

    "Physics Blocks": ItemClassification.progression,
    "Progressive Physics Blocks": ItemClassification.progression,
    "Standard Physics Blocks": ItemClassification.progression,
    "Ice Blocks": ItemClassification.progression,
    "Yellow Physics Blocks": ItemClassification.progression,
    "Concrete Blocks": ItemClassification.progression,
    "Electric Blocks": ItemClassification.progression,
    "Line Blocks": ItemClassification.progression,

    "Sliding Blocks": ItemClassification.progression,
    "Progressive Sliding Blocks": ItemClassification.progression,
    "Standard Sliding Blocks": ItemClassification.progression,
    "Yellow Sliding Blocks": ItemClassification.progression,
    "Blue Sliding Blocks": ItemClassification.progression,
    "Crystal Sliding Blocks": ItemClassification.progression,
    "Galactic Sliding Blocks": ItemClassification.progression,

    "Boss Blocks": ItemClassification.progression,
    "Progressive Boss Blocks": ItemClassification.progression,
    "Standard Star Blocks": ItemClassification.progression,
    "Yellow Star Blocks": ItemClassification.progression,
    "Blue Star Blocks": ItemClassification.progression,
    "Standard Heart Blocks": ItemClassification.progression,
    "Sliding Heart Blocks": ItemClassification.progression,
    "Delayed Heart Blocks": ItemClassification.progression,

    "Pop Blocks": ItemClassification.progression,
    "Progressive Pop Blocks": ItemClassification.progression,
    "Standard Pop Blocks": ItemClassification.progression,
    "Galactic Pop Blocks": ItemClassification.progression,

    "Bumpers": ItemClassification.progression,
    "Progressive Bumpers": ItemClassification.progression,
    "Standard Bumpers": ItemClassification.progression,
    "Directional Bumpers": ItemClassification.progression,
    "Yellow Bumpers": ItemClassification.progression,
    "Black Hole Bumpers": ItemClassification.progression,

    "Switches": ItemClassification.progression,
    "Progressive Switches": ItemClassification.progression,
    "Blue Switches": ItemClassification.progression,
    "Orange Switches": ItemClassification.progression,

    "Punchappear Blocks": ItemClassification.progression,
    "Progressive Punchappear Blocks": ItemClassification.progression,
    "Standard Punchappear Blocks": ItemClassification.progression,
    "Yellow Punchappear Blocks": ItemClassification.progression,
    "Blue Punchappear Blocks": ItemClassification.progression,
    "Orange Punchappear Blocks": ItemClassification.progression,

    "Skull Blocks": ItemClassification.progression,
    "Progressive Skull Blocks": ItemClassification.progression,
    "Yellow Skull Blocks": ItemClassification.progression,
    "Blue Skull Blocks": ItemClassification.progression,
    "Orange Skull Blocks": ItemClassification.progression,

    "Skull Rings": ItemClassification.progression,
    "Progressive Skull Rings": ItemClassification.progression,
    "Yellow Skull Rings": ItemClassification.progression,
    "Blue Skull Rings": ItemClassification.progression,

    "Enemies": ItemClassification.progression,
    "Progressive Enemies": ItemClassification.progression,
    "Gubes": ItemClassification.progression,
    "Yellow Gorbs": ItemClassification.progression,
    "Blue Gorbs": ItemClassification.progression,
    "Pixies": ItemClassification.progression,

    "Vivi Blocks": ItemClassification.progression,
    "Progressive Vivi Blocks": ItemClassification.progression,
    "Standard Vivi Blocks": ItemClassification.progression,
    "Yellow Vivi Blocks": ItemClassification.progression,
    "Firework Vivi Blocks": ItemClassification.progression,

    "Block Launchers": ItemClassification.progression,
    "Progressive Block Launchers": ItemClassification.progression,
    "Standard Block Launchers": ItemClassification.progression,
    "Wing Block Launchers": ItemClassification.progression,
    "Pearl Block Launchers": ItemClassification.progression,
    "Ice Block Launchers": ItemClassification.progression,
    "Yellow Block Launchers": ItemClassification.progression,
    "Blue Block Launchers": ItemClassification.progression,
    "Inverted Block Launchers": ItemClassification.progression,
    "Galactic Block Launchers": ItemClassification.progression,
    "Fire Block Launchers": ItemClassification.progression,

    "Launchers": ItemClassification.progression,
    "Progressive Launchers": ItemClassification.progression,
    "Standard Launchers": ItemClassification.progression,
    "Blue Pearl Launchers": ItemClassification.progression,
    "Red Pearl Launchers": ItemClassification.progression,
    "Yellow Crystal Launchers": ItemClassification.progression,
    "Blue Crystal Launchers": ItemClassification.progression,
    "Moon Launchers": ItemClassification.progression,

    "Hazards": ItemClassification.progression,
    "Progressive Hazards": ItemClassification.progression,
    "Standard Spinners": ItemClassification.progression,
    "Star Spinners": ItemClassification.progression,
    "Red Fire Rings": ItemClassification.progression,
    "Blue Fire Rings": ItemClassification.progression,

    "Bubbles": ItemClassification.progression,
    "Progressive Bubbles": ItemClassification.progression,
    "Green Bubbles": ItemClassification.progression,
    "Key Bubbles": ItemClassification.progression,
    "Number Bubbles": ItemClassification.progression,
    "Clear Bubbles": ItemClassification.progression,
    "Honey Bubbles": ItemClassification.progression,

    "Balloons": ItemClassification.progression,
    "Progressive Balloons": ItemClassification.progression,
    "Red Balloons": ItemClassification.progression,
    "Blue Balloons": ItemClassification.progression,
    "Lead Balloons": ItemClassification.progression,
    "Toggle Balloons": ItemClassification.progression,

    "Bombs": ItemClassification.progression,
    "Progressive Bombs": ItemClassification.progression,
    "Bomb Flowers": ItemClassification.progression,
    "Bomb Blocks": ItemClassification.progression,
    "Hive Bombs": ItemClassification.progression,

    "Hive Blocks": ItemClassification.progression,
    "Progressive Hive Blocks": ItemClassification.progression,
    "Blue Hive Blocks": ItemClassification.progression,
    "Red Hive Blocks": ItemClassification.progression,

    "Keys": ItemClassification.progression,
    "Progressive Keys": ItemClassification.progression,
    "Standard Key Blocks": ItemClassification.progression,
    "Key Quartets": ItemClassification.progression,
    "Ice Key Blocks": ItemClassification.progression,
    "Inverted Key Blocks": ItemClassification.progression,

    "Gravity Items": ItemClassification.progression,
    "Progressive Gravity Items": ItemClassification.progression,
    "Up Gravity Flippers": ItemClassification.progression,
    "Down Gravity Flippers": ItemClassification.progression,
    "Up Gravity Fields": ItemClassification.progression,
    "Down Gravity Fields": ItemClassification.progression,
    "Up Water": ItemClassification.progression,
    "Down Water": ItemClassification.progression,
    "Gravity Fists": ItemClassification.progression,
    "Gravity Anchors": ItemClassification.progression,

    "Lifts": ItemClassification.progression,
    "Progressive Lifts": ItemClassification.progression,
    "Arrow Lifts": ItemClassification.progression,
    "Yellow Lifts": ItemClassification.progression,
    "Hive Lifts": ItemClassification.progression,

    "Semisolids": ItemClassification.progression,
    "Progressive Semisolids": ItemClassification.progression,
    "Standard Semisolids": ItemClassification.progression,
    "Inverted Semisolids": ItemClassification.progression,
    "Toggle Semisolids": ItemClassification.progression,

    "On Off Blocks": ItemClassification.progression,
    "Timer Buttons": ItemClassification.progression,
    "Toggle Flowers": ItemClassification.progression,
    "Tethers": ItemClassification.progression,
    "Icicles": ItemClassification.progression,
    "Glass Blocks": ItemClassification.progression,
    "Vivi's Flashlight": ItemClassification.useful,
    "Thermals": ItemClassification.progression,
    "Golf Ball": ItemClassification.progression,
    "Golf Cart": ItemClassification.progression,
    "Falling Crystals": ItemClassification.progression,
    "Grab Blocks": ItemClassification.progression,
    "Mirrors": ItemClassification.progression,
    "Barrels": ItemClassification.progression,
    "Pillars": ItemClassification.progression,
    "Yellow Spin Blocks": ItemClassification.progression,
    "Trees": ItemClassification.progression,

    "Coin": ItemClassification.progression_deprioritized_skip_balancing,

    "Progressive Standard Path": ItemClassification.progression,
    "Progressive Secret Path": ItemClassification.progression,

    "1-1 Standard Exit Path": ItemClassification.progression,
    "1-2 Standard Exit Path": ItemClassification.progression,
    "1-3 Standard Exit Path": ItemClassification.progression,
    "1-4 Standard Exit Path": ItemClassification.progression,
    "1-5 Standard Exit Path": ItemClassification.progression,
    "1-6 Standard Exit Path": ItemClassification.progression,
    "1-7 Standard Exit Path": ItemClassification.progression,
    "2-1 Standard Exit Path": ItemClassification.progression,
    "2-2 Standard Exit Path": ItemClassification.progression,
    "2-3 Standard Exit Path": ItemClassification.progression,
    "2-4 Standard Exit Path": ItemClassification.progression,
    "2-5 Standard Exit Path": ItemClassification.progression,
    "3-1 Standard Exit Path": ItemClassification.progression,
    "3-2 Standard Exit Path": ItemClassification.progression,
    "3-3 Standard Exit Path": ItemClassification.progression,
    "3-4 Standard Exit Path": ItemClassification.progression,
    "3-5 Standard Exit Path": ItemClassification.progression,
    "3-6 Standard Exit Path": ItemClassification.progression,
    "4-1 Standard Exit Path": ItemClassification.progression,
    "4-2 Standard Exit Path": ItemClassification.progression,
    "4-3 Standard Exit Path": ItemClassification.progression,
    "4-4 Standard Exit Path": ItemClassification.progression,
    "4-5 Standard Exit Path": ItemClassification.progression,
    "4-6 Standard Exit Path": ItemClassification.progression,
    "4-7 Standard Exit Path": ItemClassification.progression,
    "4-8 Standard Exit Path": ItemClassification.progression,
    "5-1 Standard Exit Path": ItemClassification.progression,
    "5-2 Standard Exit Path": ItemClassification.progression,
    "5-3 Standard Exit Path": ItemClassification.progression,
    
    "1-2 Secret Exit Path": ItemClassification.progression,
    "1-4 Secret Exit Path": ItemClassification.progression,
    "2-1 Secret Exit Path": ItemClassification.progression,
    "2-C Secret Exit Path": ItemClassification.progression,
    "3-1 Secret Exit Path": ItemClassification.progression,
    "4-1 Secret Exit Path": ItemClassification.progression,
    
    "1-A Standard Exit Path": ItemClassification.progression,
    "1-B Standard Exit Path": ItemClassification.progression,
    "1-C Standard Exit Path": ItemClassification.progression,
    "2-A Standard Exit Path": ItemClassification.progression,
    "2-B Standard Exit Path": ItemClassification.progression,
    "2-C Standard Exit Path": ItemClassification.progression,
    "3-A Standard Exit Path": ItemClassification.progression,
    "3-B Standard Exit Path": ItemClassification.progression,
    "4-A Standard Exit Path": ItemClassification.progression,
    
    "1-8 Boss Exit Path": ItemClassification.progression,
    "2-6 Boss Exit Path": ItemClassification.progression,
    "3-7 Boss Exit Path": ItemClassification.progression,
    "4-9 Boss Exit Path": ItemClassification.progression,
    
    "2-D Standard Exit Path": ItemClassification.progression,
    
    "1-1 Home Exit Path": ItemClassification.progression,

    "Nothing": ItemClassification.filler
}

class FantasticFistItem(Item):
    game = "Fantastic Fist"

def get_random_filler_item_name(world: FantasticFistWorld) -> str:
    return "Nothing"

def create_item_with_correct_classification(world: FantasticFistWorld, name: str) -> FantasticFistItem:
    classification = DEFAULT_ITEM_CLASSIFICATIONS[name]

    return FantasticFistItem(name, classification, ITEM_NAME_TO_ID[name], world.player)

def create_all_items(world: FantasticFistWorld) -> None:

    itempool: list[Item] = [
        world.create_item("On Off Blocks"),
        world.create_item("Timer Buttons"),
        world.create_item("Toggle Flowers"),
        world.create_item("Tethers"),
        world.create_item("Icicles"),
        world.create_item("Glass Blocks"),
        world.create_item("Thermals"),
        world.create_item("Golf Ball"),
        world.create_item("Golf Cart"),
        world.create_item("Falling Crystals"),
        world.create_item("Grab Blocks"),
        world.create_item("Mirrors"),
        world.create_item("Barrels"),
        world.create_item("Pillars"),
        world.create_item("Yellow Spin Blocks"),
        world.create_item("Trees")
    ]

    create_item_group(world, itempool, 1, 3, world.options.destructible_blocks, False)
    create_item_group(world, itempool, 10, 6, world.options.physics_blocks, False)
    create_item_group(world, itempool, 20, 5, world.options.sliding_blocks, False)
    create_item_group(world, itempool, 30, 6, world.options.boss_blocks, False)
    create_item_group(world, itempool, 40, 2, world.options.pop_blocks, False)
    create_item_group(world, itempool, 50, 4, world.options.bumpers, False)
    create_item_group(world, itempool, 60, 2, world.options.switches, False)
    create_item_group(world, itempool, 70, 4, world.options.punchappear_blocks, False)
    extra_skull_blocks: bool = get_extra(world, world.options.extra_skull_blocks)
    create_item_group(world, itempool, 80, 3, world.options.skull_blocks, extra_skull_blocks)
    extra_skull_rings: bool = get_extra(world, world.options.extra_skull_rings)
    create_item_group(world, itempool, 90, 2, world.options.skull_rings, extra_skull_rings)
    extra_enemies: bool = get_extra(world, world.options.extra_enemies)
    create_item_group(world, itempool, 100, 4, world.options.enemies, extra_enemies)
    create_item_group(world, itempool, 110, 3, world.options.vivi_blocks, False)
    create_item_group(world, itempool, 120, 9, world.options.block_launchers, False)
    create_item_group(world, itempool, 140, 6, world.options.launchers, False)
    extra_hazards: bool = get_extra(world, world.options.extra_hazards)
    create_item_group(world, itempool, 150, 4, world.options.hazards, extra_hazards)
    create_item_group(world, itempool, 160, 5, world.options.bubbles, False)
    create_item_group(world, itempool, 170, 4, world.options.balloons, False)
    create_item_group(world, itempool, 180, 3, world.options.bombs, False)
    create_item_group(world, itempool, 190, 2, world.options.hive_blocks, False)
    create_item_group(world, itempool, 200, 4, world.options.keys, False)
    create_item_group(world, itempool, 210, 8, world.options.gravity_items, False)
    create_item_group(world, itempool, 220, 3, world.options.lifts, False)
    create_item_group(world, itempool, 230, 3, world.options.semisolids, False)

    if get_extra(world, world.options.vivis_flashlight):
        itempool.append(world.create_item("Vivi's Flashlight"))

    if world.options.paths == 0:
        # vanilla paths
        if world.options.open_world == 0:
            pass

        elif world.options.open_world == 1:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))

        elif world.options.open_world == 2:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))

        elif world.options.open_world == 3:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5)))

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))

    elif world.options.paths == 1:
        # random paths
        if world.options.open_world == 0:
            itempool += [world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29))]
            itempool += [world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15))]
            itempool += [world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5))]

            if world.options.goal != 2:
                itempool.append(world.create_item("1-1 Home Exit Path"))

        elif world.options.open_world == 1:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            itempool += [world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15))]
            itempool += [world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5))]

            if world.options.goal != 2:
                itempool.append(world.create_item("1-1 Home Exit Path"))

        elif world.options.open_world == 2:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))
            itempool += [world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5))]

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))

        elif world.options.open_world == 3:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5)))

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))

    elif world.options.paths == 2:
        # progressive paths
        if world.options.open_world == 0:
            itempool += [world.create_item("Progressive Standard Path") for _ in range(33)]
            itempool += [world.create_item("Progressive Secret Path") for _ in range(16)]

            if world.options.goal != 2:
                itempool.append(world.create_item("Progressive Secret Path"))
            
        elif world.options.open_world == 1:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))            
            itempool += [world.create_item("Progressive Standard Path") for _ in range(4)]
            itempool += [world.create_item("Progressive Secret Path") for _ in range(16)]

            if world.options.goal != 2:
                itempool.append(world.create_item("Progressive Secret Path"))

        elif world.options.open_world == 2:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))
            itempool += [world.create_item("Progressive Standard Path") for _ in range(4)]
            itempool.append(world.create_item("Progressive Secret Path"))

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))

        elif world.options.open_world == 3:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[310 + k] for k in range(29)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[340 + k] for k in range(15)))
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[360 + k] for k in range(5)))

            if world.options.goal != 2:
                world.push_precollected(world.create_item("1-1 Home Exit Path"))
    
    number_of_items = len(itempool)
    number_of_unfilled_locations = len(world.multiworld.get_unfilled_locations(world.player))
    needed_number_of_filler_items = number_of_unfilled_locations - number_of_items

    coin_amt = world.options.max_coin_amount

    if coin_amt > needed_number_of_filler_items:
        coin_amt = needed_number_of_filler_items

    itempool += [world.create_item("Coin") for _ in range(coin_amt)]

    needed_number_of_filler_items -= coin_amt

    itempool += [world.create_filler() for _ in range(needed_number_of_filler_items)]

def create_item_group(world: FantasticFistWorld, itempool: list[Item], start_id: int, choice_amt: int, option_selected: int, include_extra: bool) -> None:
    if option_selected == 0:
        option_selected = world.options.default_item_groups

    if option_selected == 1:
        # The item group is seperated.
        itempool += [world.create_item(ID_TO_ITEM_NAME[start_id + 2 + k]) for k in range(choice_amt)]
        if include_extra:
            itempool += [world.create_item(ID_TO_ITEM_NAME[start_id + 2 + k]) for k in range(choice_amt)]
    elif option_selected == 2:
        # The item group is progressive.
        itempool += [world.create_item(ID_TO_ITEM_NAME[start_id + 1]) for _ in range(choice_amt)]
        if include_extra:
            itempool.append(world.create_item(ID_TO_ITEM_NAME[start_id + 1]))
    elif option_selected == 3:
        # The item group is grouped.
        itempool.append(world.create_item(ID_TO_ITEM_NAME[start_id]))
        if include_extra:
            itempool.append(world.create_item(ID_TO_ITEM_NAME[start_id ]))
    elif option_selected == 4:
        # The item group is precollected.
        world.push_precollected(world.create_item(ID_TO_ITEM_NAME[start_id]))
        if include_extra:
            world.push_precollected(world.create_item(ID_TO_ITEM_NAME[start_id]))

def get_extra(world: FantasticFistWorld, option_selected: int) -> bool:
    if option_selected == 0:
        option_selected = world.options.default_extra_items

    return option_selected == 1