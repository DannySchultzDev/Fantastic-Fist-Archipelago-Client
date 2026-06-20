from __future__ import annotations

from typing import TYPE_CHECKING

from rule_builder.options import OptionFilter
from rule_builder.rules import Has, HasAll, Rule

if TYPE_CHECKING:
    from .world import FantasticFistWorld

HAS_SMASH_BLOCKS = (Has("Destructible Blocks") | 
                    Has("Progressive Destructible Blocks", count = 1) |
                    Has("Smash Blocks"))
HAS_BURNABLE_BLOCKS = (Has("Destructible Blocks") |
                        Has("Progressive Destructible Blocks", count = 2) |
                        Has("Burnable Blocks"))
HAS_SNAKE_BLOCKS = (Has("Destructible Blocks") |
                    Has("Progressive Destructible Blocks", count = 3) |
                    Has("Snake Blocks"))

HAS_STANDARD_PHYSICS_BLOCKS = (Has("Physics Blocks") |
                                Has("Progressive Physics Blocks", count = 1) |
                                Has("Standard Physics Blocks"))
HAS_ICE_BLOCKS = (Has("Physics Blocks") |
                    Has("Progressive Physics Blocks", count = 2) |
                    Has("Ice Blocks"))
HAS_YELLOW_PHYSICS_BLOCKS = (Has("Physics Blocks") |
                                Has("Progressive Physics Blocks", count = 3) |
                                Has("Yellow Physics Blocks"))
HAS_CONCRETE_BLOCKS = (Has("Physics Blocks") |
                        Has("Progressive Physics Blocks", count = 4) |
                        Has("Concrete Blocks"))
HAS_ELECTRIC_BLOCKS = (Has("Physics Blocks") |
                        Has("Progressive Physics Blocks", count = 5) |
                        Has("Electric Blocks"))
HAS_LINE_BLOCKS = (Has("Physics Blocks") |
                    Has("Progressive Physics Blocks", count = 6) |
                    Has("Line Blocks"))

HAS_STANDARD_SLIDING_BLOCKS = (Has("Sliding Blocks") | 
                                Has("Progressive Sliding Blocks", count = 1) | 
                                Has("Standard Sliding Blocks"))
HAS_YELLOW_SLIDING_BLOCKS = (Has("Sliding Blocks") | 
                                Has("Progressive Sliding Blocks", count = 2) | 
                                Has("Yellow Sliding Blocks"))
HAS_BLUE_SLIDING_BLOCKS = (Has("Sliding Blocks") | 
                            Has("Progressive Sliding Blocks", count = 3) | 
                            Has("Blue Sliding Blocks"))
HAS_CRYSTAL_SLIDING_BLOCKS = (Has("Sliding Blocks") | 
                                Has("Progressive Sliding Blocks", count = 4) | 
                                Has("Crystal Sliding Blocks"))
HAS_GALACTIC_SLIDING_BLOCKS = (Has("Sliding Blocks") | 
                                Has("Progressive Sliding Blocks", count = 5) | 
                                Has("Galactic Sliding Blocks"))

HAS_STANDARD_STAR_BLOCKS = (Has("Boss Blocks") | 
                            Has("Progressive Boss Blocks", count = 1) | 
                            Has("Standard Star Blocks"))
HAS_YELLOW_STAR_BLOCKS = (Has("Boss Blocks") | 
                            Has("Progressive Boss Blocks", count = 2) | 
                            Has("Yellow Star Blocks"))
HAS_BLUE_STAR_BLOCKS = (Has("Boss Blocks") | 
                        Has("Progressive Boss Blocks", count = 3) | 
                        Has("Blue Star Blocks"))
HAS_STANDARD_HEART_BLOCKS = (Has("Boss Blocks") | 
                                Has("Progressive Boss Blocks", count = 4) | 
                                Has("Standard Heart Blocks"))
HAS_SLIDING_HEART_BLOCKS = (Has("Boss Blocks") | 
                            Has("Progressive Boss Blocks", count = 5) | 
                            Has("Sliding Heart Blocks"))
HAS_DELAYED_HEART_BLOCKS = (Has("Boss Blocks") | 
                            Has("Progressive Boss Blocks", count = 6) | 
                            Has("Delayed Heart Blocks"))

HAS_STANDARD_POP_BLOCKS = (Has("Pop Blocks") | 
                           Has("Progressive Pop Blocks", count = 1) | 
                           Has("Standard Pop Blocks"))
HAS_GALACTIC_POP_BLOCKS = (Has("Pop Blocks") | 
                           Has("Progressive Pop Blocks", count = 2) | 
                           Has("Galactic Pop Blocks"))

HAS_STANDARD_BUMPERS = (Has("Bumpers") | 
                        Has("Progressive Bumpers", count = 1) | 
                        Has("Standard Bumpers"))
HAS_DIRECTIONAL_BUMPERS = (Has("Bumpers") | 
                           Has("Progressive Bumpers", count = 2) | 
                           Has("Directional Bumpers"))
HAS_YELLOW_BUMPERS = (Has("Bumpers") | 
                      Has("Progressive Bumpers", count = 3) | 
                      Has("Yellow Bumpers"))
HAS_BLACK_HOLE_BUMPERS = (Has("Bumpers") | 
                          Has("Progressive Bumpers", count = 4) | 
                          Has("Black Hole Bumpers"))

HAS_BLUE_SWITCHES = (Has("Switches") | 
                     Has("Progressive Switches", count = 1) | 
                     Has("Blue Switches"))
HAS_ORAGNGE_SWITCHES = (Has("Switches") | 
                        Has("Progressive Switches", count = 2) | 
                        Has("Orange Switches"))

HAS_STANDARD_PUNCHAPPEAR_BLOCKS = (Has("Punchappear Blocks") | 
                                   Has("Progressive Punchappear Blocks", count = 1) | 
                                   Has("Standard Punchappear Blocks"))
HAS_YELLOW_PUNCHAPPEAR_BLOCKS = (Has("Punchappear Blocks") | 
                                 Has("Progressive Punchappear Blocks", count = 2) | 
                                 Has("Yellow Punchappear Blocks"))
HAS_BLUE_PUNCHAPPEAR_BLOCKS = (Has("Punchappear Blocks") | 
                               Has("Progressive Punchappear Blocks", count = 3) | 
                               Has("Blue Punchappear Blocks"))
HAS_ORANGE_PUNCHAPPEAR_BLOCKS = (Has("Punchappear Blocks") | 
                                 Has("Progressive Punchappear Blocks", count = 4) | 
                                 Has("Orange Punchappear Blocks"))

HAS_YELLOW_SKULL_BLOCKS = (Has("Skull Blocks") | 
                           Has("Progressive Skull Blocks", count = 1) | 
                           Has("Yellow Skull Blocks"))
HAS_BLUE_SKULL_BLOCKS = (Has("Skull Blocks") | 
                         Has("Progressive Skull Blocks", count = 2) | 
                         Has("Blue Skull Blocks"))
HAS_ORANGE_SKULL_BLOCKS = (Has("Skull Blocks") | 
                           Has("Progressive Skull Blocks", count = 3) | 
                           Has("Orange Skull Blocks"))

HAS_YELLOW_SKULL_RINGS = (Has("Skull Rings") | 
                          Has("Progressive Skull Rings", count = 1) | 
                          Has("Yellow Skull Rings"))
HAS_BLUE_SKULL_RINGS = (Has("Skull Rings") | 
                        Has("Progressive Skull Rings", count = 2) | 
                        Has("Blue Skull Rings"))

HAS_GUBES = (Has("Enemies") | 
             Has("Progressive Enemies", count = 1) | 
             Has("Gubes"))
HAS_YELLOW_GORBS = (Has("Enemies") | 
                    Has("Progressive Enemies", count = 2) | 
                    Has("Yellow Gorbs"))
HAS_BLUE_GORBS = (Has("Enemies") | 
                  Has("Progressive Enemies", count = 3) | 
                  Has("Blue Gorbs"))
HAS_PIXIES = (Has("Enemies") | 
              Has("Progressive Enemies", count = 4) | 
              Has("Pixies"))

HAS_STANDARD_VIVI_BLOCKS = (Has("Vivi Blocks") | 
                            Has("Progressive Vivi Blocks", count = 1) | 
                            Has("Standard Vivi Blocks"))
HAS_YELLOW_VIVI_BLOCKS = (Has("Vivi Blocks") | 
                          Has("Progressive Vivi Blocks", count = 2) | 
                          Has("Yellow Vivi Blocks"))
HAS_FIREWORK_VIVI_BLOCKS = (Has("Vivi Blocks") | 
                            Has("Progressive Vivi Blocks", count = 3) | 
                            Has("Firework Vivi Blocks"))

HAS_STANDARD_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                                Has("Progressive Block Launchers", count = 1) | 
                                Has("Standard Block Launchers"))
HAS_WING_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                            Has("Progressive Block Launchers", count = 2) | 
                            Has("Wing Block Launchers"))
HAS_PEARL_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                             Has("Progressive Block Launchers", count = 3) | 
                             Has("Pearl Block Launchers"))
HAS_ICE_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                           Has("Progressive Block Launchers", count = 4) | 
                           Has("Ice Block Launchers"))
HAS_YELLOW_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                              Has("Progressive Block Launchers", count = 5) | 
                              Has("Yellow Block Launchers"))
HAS_BLUE_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                            Has("Progressive Block Launchers", count = 6) | 
                            Has("Blue Block Launchers"))
HAS_INVERTED_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                                Has("Progressive Block Launchers", count = 7) | 
                                Has("Inverted Block Launchers"))
HAS_GALACTIC_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                                Has("Progressive Block Launchers", count = 8) | 
                                Has("Galactic Block Launchers"))
HAS_FIRE_BLOCK_LAUNCHERS = (Has("Block Launchers") | 
                            Has("Progressive Block Launchers", count = 9) | 
                            Has("Fire Block Launchers"))

HAS_STANDARD_LAUNCHERS = (Has("Launchers") | 
                          Has("Progressive Launchers", count = 1) | 
                          Has("Standard Launchers"))
HAS_BLUE_PEARL_LAUNCHERS = (Has("Launchers") | 
                            Has("Progressive Launchers", count = 2) | 
                            Has("Blue Pearl Launchers"))
HAS_RED_PEARL_LAUNCHERS = (Has("Launchers") | 
                           Has("Progressive Launchers", count = 3) | 
                           Has("Red Pearl Launchers"))
HAS_YELLOW_CRYSTAL_LAUNCHERS = (Has("Launchers") | 
                                Has("Progressive Launchers", count = 4) | 
                                Has("Yellow Crystal Launchers"))
HAS_BLUE_CRYSTAL_LAUNCHERS = (Has("Launchers") | 
                              Has("Progressive Launchers", count = 5) | 
                              Has("Blue Crystal Launchers"))
HAS_MOON_LAUNCHERS = (Has("Launchers") | 
                      Has("Progressive Launchers", count = 6) | 
                      Has("Moon Launchers"))

HAS_STANDARD_SPINNERS = (Has("Hazards") | 
                         Has("Progressive Hazards", count = 1) | 
                         Has("Standard Spinners"))
HAS_STAR_SPINNERS = (Has("Hazards") | 
                     Has("Progressive Hazards", count = 2) | 
                     Has("Star Spinners"))
HAS_RED_FIRE_RINGS = (Has("Hazards") | 
                      Has("Progressive Hazards", count = 3) | 
                      Has("Red Fire Rings"))
HAS_BLUE_FIRE_RINGS = (Has("Hazards") | 
                       Has("Progressive Hazards", count = 4) | 
                       Has("Blue Fire Rings"))

HAS_GREEN_BUBBLES = (Has("Bubbles") | 
                          Has("Progressive Bubbles", count = 1) | 
                          Has("Green Bubbles"))
HAS_KEY_BUBBLES = (Has("Bubbles") | 
                   Has("Progressive Bubbles", count = 2) | 
                   Has("Key Bubbles"))
HAS_NUMBER_BUBBLES = (Has("Bubbles") | 
                      Has("Progressive Bubbles", count = 3) | 
                      Has("Number Bubbles"))
HAS_CLEAR_BUBBLES = (Has("Bubbles") | 
                     Has("Progressive Bubbles", count = 4) | 
                     Has("Clear Bubbles"))
HAS_HONEY_BUBBLES = (Has("Bubbles") | 
                     Has("Progressive Bubbles", count = 5) | 
                     Has("Honey Bubbles"))

HAS_RED_BALLOONS = (Has("Balloons") | 
                    Has("Progressive Balloons", count = 1) | 
                    Has("Red Balloons"))
HAS_BLUE_BALLOONS = (Has("Balloons") | 
                     Has("Progressive Balloons", count = 2) | 
                     Has("Blue Balloons"))
HAS_LEAD_BALLOONS = (Has("Balloons") | 
                     Has("Progressive Balloons", count = 3) | 
                     Has("Lead Balloons"))
HAS_TOGGLE_BALLOONS = (Has("Balloons") | 
                       Has("Progressive Balloons", count = 4) | 
                       Has("Toggle Balloons"))

HAS_BOMB_FLOWERS = (Has("Bombs") | 
                    Has("Progressive Bombs", count = 1) | 
                    Has("Bomb Flowers"))
HAS_BOMB_BLOCKS = (Has("Bombs") | 
                   Has("Progressive Bombs", count = 2) | 
                   Has("Bomb Blocks"))
HAS_HIVE_BOMBS = (Has("Bombs") | 
                 Has("Progressive Bombs", count = 3) | 
                 Has("Hive Bombs"))

HAS_BLUE_HIVE_BLOCKS = (Has("Hive Blocks") | 
                        Has("Progressive Hive Blocks", count = 1) | 
                        Has("Blue Hive Blocks"))
HAS_RED_HIVE_BLOCKS = (Has("Hive Blocks") | 
                       Has("Progressive Hive Blocks", count = 2) | 
                       Has("Red Hive Blocks"))

HAS_STANDARD_KEY_BLOCKS = (Has("Keys") | 
                           Has("Progressive Keys", count = 1) | 
                           Has("Standard Key Blocks"))
HAS_KEY_QUARTETS = (Has("Keys") | 
                    Has("Progressive Keys", count = 2) | 
                    Has("Key Quartets"))
HAS_ICE_KEY_BLOCKS = (Has("Keys") | 
                      Has("Progressive Keys", count = 3) | 
                      Has("Ice Key Blocks"))
HAS_INVERTED_KEY_BLOCKS = (Has("Keys") | 
                           Has("Progressive Keys", count = 4) | 
                           Has("Inverted Key Blocks"))

HAS_UP_GRAVITY_FLIPPERS = (Has("Gravity Items") | 
                           Has("Progressive Gravity Items", count = 1) | 
                           Has("Up Gravity Flippers"))
HAS_DOWN_GRAVITY_FLIPPERS = (Has("Gravity Items") | 
                             Has("Progressive Gravity Items", count = 2) | 
                             Has("Down Gravity Flippers"))
HAS_UP_GRAVITY_FIELDS = (Has("Gravity Items") | 
                         Has("Progressive Gravity Items", count = 3) | 
                         Has("Up Gravity Fields"))
HAS_DOWN_GRAVITY_FIELDS = (Has("Gravity Items") | 
                           Has("Progressive Gravity Items", count = 4) | 
                           Has("Down Gravity Fields"))
HAS_UP_WATER = (Has("Gravity Items") | 
                Has("Progressive Gravity Items", count = 5) | 
                Has("Up Water"))
HAS_DOWN_WATER = (Has("Gravity Items") | 
                  Has("Progressive Gravity Items", count = 6) | 
                  Has("Down Water"))
HAS_GRAVITY_FISTS = (Has("Gravity Items") | 
                     Has("Progressive Gravity Items", count = 7) | 
                     Has("Gravity Fists"))
HAS_GRAVITY_ANCHORS = (Has("Gravity Items") | 
                       Has("Progressive Gravity Items", count = 8) | 
                       Has("Gravity Anchors"))

HAS_ARROW_LIFTS = (Has("Lifts") | 
                   Has("Progressive Lifts", count = 1) | 
                   Has("Arrow Lifts"))
HAS_YELLOW_LIFTS = (Has("Lifts") | 
                    Has("Progressive Lifts", count = 2) | 
                    Has("Yellow Lifts"))
HAS_HIVE_LIFTS = (Has("Lifts") | 
                  Has("Progressive Lifts", count = 3) | 
                  Has("Hive Lifts"))

HAS_STANDARD_SEMISOLIDS = (Has("Semisolids") | 
                           Has("Progressive Semisolids", count = 1) | 
                           Has("Standard Semisolids"))
HAS_INVERTED_SEMISOLIDS = (Has("Semisolids") | 
                           Has("Progressive Semisolids", count = 2) | 
                           Has("Inverted Semisolids"))
HAS_TOGGLE_SEMISOLIDS = (Has("Semisolids") | 
                         Has("Progressive Semisolids", count = 3) | 
                         Has("Toggle Semisolids"))

HAS_ON_OFF_BLOCKS = Has("On Off Blocks")
HAS_TIMER_BUTTONS = Has("Timer Buttons")
HAS_TOGGLE_FLOWERS = Has("Toggle Flowers")
HAS_TETHERS = Has("Tethers")
HAS_ICICLES = Has("Icicles")
HAS_GLASS_BLOCKS = Has("Glass Blocks")
HAS_THERMALS = Has("Thermals")
HAS_GOLF_BALL = Has("Golf Ball")
HAS_GOLF_CART = Has("Golf Cart")
HAS_FALLING_CRYSTALS = Has("Falling Crystals")
HAS_GRAB_BLOCKS = Has("Grab Blocks")
HAS_MIRRORS = Has("Mirrors")
HAS_BARRELS = Has("Barrels")
HAS_PILLARS = Has("Pillars")
HAS_YELLOW_SPIN_BLOCKS = Has("Yellow Spin Blocks")
HAS_TREES = Has("Trees")

# Intended, Simple, Advanced, Glitched
ITEM_REQUIREMENTS = {
    #Introduction
    "Introduction Room 1 Door": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS & 
                                  HAS_DOWN_WATER),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS)],
    "Introduction Coin 1": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                            (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                            (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                            (HAS_SMASH_BLOCKS)],
    "Introduction Room 2 Door": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS)],
    "Introduction Checkpoint 1": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS & 
                                   HAS_DOWN_WATER),
                                  (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                                  (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                                  (HAS_SMASH_BLOCKS)],
    "Introduction Room 3 Door": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS & 
                                  HAS_DOWN_WATER),
                                 (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                                 (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                                 (HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS)],
    "Introduction Coin 2": [(HAS_SMASH_BLOCKS),
                            None,
                            None,
                            None],
    "Introduction Level Clear": [(HAS_SMASH_BLOCKS & HAS_DOWN_WATER),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS),
                                 (HAS_SMASH_BLOCKS)],
    #The Caves
    "The Caves Coin 1": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS & 
                          HAS_STANDARD_KEY_BLOCKS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS)],
    "The Caves Room 1 Door": [(HAS_SMASH_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS & 
                               HAS_STANDARD_KEY_BLOCKS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS)],
    "The Caves Checkpoint 1": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS)],
    "The Caves Load Bearing Collectible": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS & 
                                            HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS &
                                            HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS &
                                            HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS,
                                            HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS)],
    "The Caves Room 2 Door": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS)],
    "The Caves Coin 2": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS),
                         (HAS_STANDARD_BLOCK_LAUNCHERS),
                         (HAS_STANDARD_PHYSICS_BLOCKS | HAS_STANDARD_BLOCK_LAUNCHERS),
                         (HAS_STANDARD_PHYSICS_BLOCKS | HAS_STANDARD_BLOCK_LAUNCHERS)],
    "The Caves Checkpoint 2": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS & 
                                HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS)],
    "The Caves Room 3 Door": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS & 
                               HAS_WING_BLOCK_LAUNCHERS & HAS_STANDARD_SPINNERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS &
                               HAS_STANDARD_SPINNERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS &
                               HAS_STANDARD_SPINNERS),
                              (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_WING_BLOCK_LAUNCHERS &
                               HAS_STANDARD_SPINNERS)],
    "The Caves Coin 3": [(HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS & 
                          HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_SPINNERS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS &
                          HAS_STANDARD_BLOCK_LAUNCHERS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                         (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS)],
    "The Caves Level Clear": [(HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS & 
                               HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_SPINNERS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS &
                               HAS_STANDARD_BLOCK_LAUNCHERS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS),
                              (HAS_SMASH_BLOCKS & HAS_STANDARD_KEY_BLOCKS)],
    #Get A Grip
    "Get A Grip Coin 1": [(HAS_ON_OFF_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                          (HAS_ON_OFF_BLOCKS),
                          (HAS_ON_OFF_BLOCKS),
                          (HAS_ON_OFF_BLOCKS)],
    "Get A Grip Room 1 Door": [(HAS_ON_OFF_BLOCKS & HAS_STANDARD_PHYSICS_BLOCKS),
                               (HAS_ON_OFF_BLOCKS),
                               (HAS_ON_OFF_BLOCKS),
                               (HAS_ON_OFF_BLOCKS)],
    "Get A Grip Checkpoint 1": [(HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                 HAS_GUBES & HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_ON_OFF_BLOCKS)],
    "Get A Grip Room 2 Door": [(HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_GUBES & HAS_STANDARD_BLOCK_LAUNCHERS),
                               (HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS & HAS_SMASH_BLOCKS),
                               (HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS & HAS_SMASH_BLOCKS),
                               (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS)],
    "Get A Grip Checkpoint 2": [(HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                                (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS)],
    "Get A Grip Level Clear": [(HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                               (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                               (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS),
                               (HAS_STANDARD_LAUNCHERS & HAS_ON_OFF_BLOCKS)],
    #Verticality
    "Verticality Room 1 Door": [(HAS_STANDARD_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                 HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS),
                                (HAS_STANDARD_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_STANDARD_BLOCK_LAUNCHERS),
                                None],
    "Verticality Load Bearing Collectible": [(HAS_STANDARD_LAUNCHERS & HAS_STANDARD_SPINNERS & 
                                              HAS_STANDARD_BLOCK_LAUNCHERS),
                                             (HAS_STANDARD_LAUNCHERS & HAS_STANDARD_BLOCK_LAUNCHERS),
                                             (HAS_STANDARD_LAUNCHERS & HAS_STANDARD_BLOCK_LAUNCHERS),
                                             (HAS_STANDARD_BLOCK_LAUNCHERS)],
    "Verticality Coin 1": [(HAS_STANDARD_LAUNCHERS & HAS_STANDARD_SPINNERS &
                            HAS_STANDARD_BUMPERS),
                           (HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_LAUNCHERS)],
    "Verticality Room 2 Side Door": [(HAS_STANDARD_LAUNCHERS & HAS_STANDARD_SPINNERS &
                                      HAS_STANDARD_BUMPERS),
                                      (HAS_STANDARD_LAUNCHERS),
                                      (HAS_STANDARD_LAUNCHERS),
                                      (HAS_STANDARD_LAUNCHERS)],
    "Verticality Checkpoint 1": [(HAS_STANDARD_BLOCK_LAUNCHERS),
                                 (HAS_STANDARD_BLOCK_LAUNCHERS),
                                 (HAS_STANDARD_BLOCK_LAUNCHERS),
                                 (HAS_STANDARD_BLOCK_LAUNCHERS)],
    "Verticality Coin 2": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS)],
    "Verticality Room 2 Door": [(HAS_STANDARD_LAUNCHERS & HAS_STANDARD_SPINNERS &
                                 HAS_STANDARD_BUMPERS),
                                (HAS_STANDARD_LAUNCHERS),
                                (HAS_STANDARD_LAUNCHERS),
                                (HAS_STANDARD_LAUNCHERS)],
    "Verticality Room 3 Door": [(HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS &
                                 HAS_STANDARD_PHYSICS_BLOCKS & HAS_STANDARD_BUMPERS &
                                 HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_SPINNERS &
                                 HAS_STANDARD_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS),
                                (HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS &
                                 HAS_STANDARD_BUMPERS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                 HAS_STANDARD_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS),
                                (HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS & (
                                 HAS_STANDARD_PHYSICS_BLOCKS | (HAS_STANDARD_BUMPERS & 
                                 HAS_STANDARD_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS))),
                                (HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS & (
                                 HAS_STANDARD_PHYSICS_BLOCKS | (HAS_STANDARD_BUMPERS & 
                                 HAS_STANDARD_LAUNCHERS)))],
    "Verticality Coin 3": [(HAS_STANDARD_VIVI_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS &
                            HAS_STANDARD_LAUNCHERS & HAS_STANDARD_BUMPERS & 
                            HAS_STANDARD_SPINNERS),
                           (HAS_STANDARD_VIVI_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS &
                            HAS_STANDARD_LAUNCHERS & HAS_STANDARD_BUMPERS & 
                            HAS_STANDARD_SPINNERS),
                           (HAS_STANDARD_VIVI_BLOCKS & (HAS_STANDARD_BLOCK_LAUNCHERS | (
                            HAS_STANDARD_LAUNCHERS & HAS_STANDARD_BUMPERS))),
                           (HAS_STANDARD_VIVI_BLOCKS)],
    "Verticality Level Clear": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS &
                                 HAS_STANDARD_BUMPERS & HAS_STANDARD_SPINNERS & 
                                 HAS_STANDARD_VIVI_BLOCKS),
                                (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_SPINNERS & (
                                 HAS_STANDARD_VIVI_BLOCKS | (HAS_STANDARD_LAUNCHERS &
                                 HAS_STANDARD_BUMPERS))),
                                (HAS_STANDARD_BLOCK_LAUNCHERS | (HAS_STANDARD_LAUNCHERS & 
                                HAS_STANDARD_BUMPERS)),
                                None],
    #Catch A Ride
    "Catch A Ride Room 1 Door": [(HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS)],
    "Catch A Ride Coin 1": [(HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS)],
    "Catch A Ride Room 2 Door": [(HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS)],
    "Catch A Ride Coin 2": [(HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS),
                            (HAS_STANDARD_SLIDING_BLOCKS)],
    "Catch A Ride Checkpoint 1": [(HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS & 
                                   HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS &
                                   HAS_STANDARD_BLOCK_LAUNCHERS),
                                  (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                                   HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS &
                                   HAS_STANDARD_BLOCK_LAUNCHERS),
                                  (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                                   HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                                  (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                                   HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS)],
    "Catch A Ride Coin 3": [(HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS & 
                             HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS &
                             HAS_STANDARD_BLOCK_LAUNCHERS),
                            (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                             HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS &
                             HAS_STANDARD_BLOCK_LAUNCHERS),
                            (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                             HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                            (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                             HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS)],
    "Catch A Ride Room 3 Door": [(HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                                  HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS &
                                  HAS_STANDARD_BLOCK_LAUNCHERS),
                                 (HAS_SMASH_BLOCKS & HAS_STANDARD_SLIDING_BLOCKS &
                                  HAS_ON_OFF_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                                 (HAS_SMASH_BLOCKS & (HAS_ON_OFF_BLOCKS |
                                  HAS_STANDARD_SLIDING_BLOCKS)),
                                 (HAS_SMASH_BLOCKS)],
    "Catch A Ride Level Clear": [(HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SLIDING_BLOCKS)],
    #Chaos Cavern
    "Chaos Cavern Room 1 Door": [(HAS_STANDARD_BUMPERS & HAS_STANDARD_SPINNERS &
                                  HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS & 
                                  HAS_ON_OFF_BLOCKS),
                                 (HAS_STANDARD_BUMPERS & HAS_STANDARD_SPINNERS &
                                  HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS & 
                                  HAS_ON_OFF_BLOCKS),
                                 (HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS & (
                                  HAS_STANDARD_BLOCK_LAUNCHERS | ( HAS_STANDARD_SPINNERS &
                                  HAS_STANDARD_LAUNCHERS))),
                                 (HAS_ON_OFF_BLOCKS & (HAS_STANDARD_LAUNCHERS | 
                                  HAS_STANDARD_BLOCK_LAUNCHERS | (HAS_STANDARD_BUMPERS & 
                                  HAS_STANDARD_SPINNERS)))],
    "Chaos Cavern Room 2 Door": [(HAS_STANDARD_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                  HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                  HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_SLIDING_BLOCKS),
                                 (HAS_STANDARD_SPINNERS | (HAS_STANDARD_BLOCK_LAUNCHERS & 
                                  HAS_STANDARD_SLIDING_BLOCKS))],
    "Chaos Cavern Coin 1": [(HAS_ON_OFF_BLOCKS & HAS_STANDARD_VIVI_BLOCKS &
                             HAS_STANDARD_SPINNERS & HAS_SMASH_BLOCKS &
                             HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_KEY_BLOCKS),
                            (HAS_ON_OFF_BLOCKS & HAS_STANDARD_VIVI_BLOCKS &
                             HAS_STANDARD_SPINNERS),
                            (HAS_ON_OFF_BLOCKS & HAS_STANDARD_VIVI_BLOCKS),
                            None],
    "Chaos Cavern Level Clear": [(HAS_ON_OFF_BLOCKS & HAS_STANDARD_VIVI_BLOCKS &
                                  HAS_STANDARD_SPINNERS & HAS_SMASH_BLOCKS &
                                  HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_KEY_BLOCKS),
                                 (HAS_ON_OFF_BLOCKS),
                                 (HAS_ON_OFF_BLOCKS),
                                 None],
    #Holding On
    "Holding On Checkpoint 1": [(HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                 HAS_STANDARD_SPINNERS),
                                (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                 HAS_STANDARD_SPINNERS),
                                (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                 HAS_STANDARD_SPINNERS),
                                (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                 HAS_STANDARD_SPINNERS)],
    "Holding On Room 1 Door": [(HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_SPINNERS & HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_SPINNERS & HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_SPINNERS & HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_ON_OFF_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_SPINNERS & HAS_STANDARD_PUNCHAPPEAR_BLOCKS)],
    "Holding On Checkpoint 2": [(HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                 HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                 HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                 HAS_STANDARD_BLOCK_LAUNCHERS),
                                (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS)],
    "Holding On Room 2 Door": [(HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS & 
                                HAS_SMASH_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS & 
                                HAS_SMASH_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS &
                                HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS & 
                                HAS_SMASH_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                HAS_SMASH_BLOCKS)],
    "Holding On Room 3 Door": [(HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_SPINNERS & HAS_GUBES &
                                HAS_STANDARD_BUMPERS & HAS_STANDARD_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_GUBES & HAS_STANDARD_BUMPERS & 
                                HAS_STANDARD_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_SMASH_BLOCKS &
                                HAS_STANDARD_BUMPERS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_SMASH_BLOCKS)],
    "Holding On Coin 1": [(HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                          (HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                          (HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                          (HAS_STANDARD_PUNCHAPPEAR_BLOCKS)],
    "Holding On Level Clear": [(HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS),
                               (HAS_STANDARD_PUNCHAPPEAR_BLOCKS)],
    #Fist Fight
    "Fist Fight Room 1 Door": [(HAS_STAR_SPINNERS & HAS_STANDARD_SPINNERS),
                               (HAS_STAR_SPINNERS),
                               (HAS_STAR_SPINNERS),
                               (HAS_STAR_SPINNERS)],
    "Fist Fight Room 2 Door": [(HAS_STAR_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS & 
                                HAS_STANDARD_LAUNCHERS & HAS_STANDARD_SLIDING_BLOCKS),
                               (HAS_STAR_SPINNERS & HAS_STANDARD_BLOCK_LAUNCHERS & 
                                HAS_STANDARD_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS),
                               (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_STANDARD_LAUNCHERS)],
    "Fist Fight Room 3 Door": [(HAS_STANDARD_VIVI_BLOCKS & HAS_STANDARD_SPINNERS),
                               (HAS_STANDARD_VIVI_BLOCKS & HAS_STANDARD_SPINNERS),
                               (HAS_STANDARD_VIVI_BLOCKS),
                               (HAS_STANDARD_VIVI_BLOCKS)],
    "Fist Fight Room 4 Door": [(HAS_WING_BLOCK_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS & 
                                HAS_ON_OFF_BLOCKS & HAS_STAR_SPINNERS),
                               (HAS_WING_BLOCK_LAUNCHERS & HAS_STANDARD_VIVI_BLOCKS),
                               (HAS_STANDARD_VIVI_BLOCKS),
                               (HAS_STANDARD_VIVI_BLOCKS | HAS_ON_OFF_BLOCKS)],
    "Fist Fight Room 5 Door": [(HAS_STAR_SPINNERS & HAS_STANDARD_STAR_BLOCKS & 
                                HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STAR_SPINNERS & HAS_STANDARD_STAR_BLOCKS &
                                HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STAR_SPINNERS & HAS_STANDARD_STAR_BLOCKS),
                               (HAS_STAR_SPINNERS & HAS_STANDARD_STAR_BLOCKS)],
    "Fist Fight Heart 1": [(HAS_STANDARD_STAR_BLOCKS),
                           (HAS_STANDARD_STAR_BLOCKS),
                           (HAS_STANDARD_STAR_BLOCKS),
                           (HAS_STANDARD_STAR_BLOCKS)],
    "Fist Fight Heart 2": [(HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS)],
    "Fist Fight Heart 3": [(HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS)],
    "Fist Fight Level Clear": [(HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_STAR_BLOCKS & HAS_WING_BLOCK_LAUNCHERS)],
    #Depths
    "Depths Room 1 Door": [(HAS_STANDARD_BLOCK_LAUNCHERS & HAS_SMASH_BLOCKS & 
                            HAS_DOWN_WATER & HAS_STANDARD_SPINNERS & 
                            HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS),
                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_SMASH_BLOCKS & 
                            HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS),
                           (HAS_STANDARD_BLOCK_LAUNCHERS & HAS_SMASH_BLOCKS & 
                            HAS_STANDARD_KEY_BLOCKS & HAS_ON_OFF_BLOCKS),
                           (HAS_ON_OFF_BLOCKS)],
    "Depths Room 2 Door": [(HAS_STANDARD_BUMPERS & HAS_STANDARD_LAUNCHERS &
                            HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_BUMPERS & HAS_STANDARD_LAUNCHERS &
                            HAS_ON_OFF_BLOCKS & HAS_STANDARD_BLOCK_LAUNCHERS),
                           (HAS_STANDARD_BUMPERS & HAS_STANDARD_LAUNCHERS &
                            HAS_ON_OFF_BLOCKS),
                           (HAS_STANDARD_BUMPERS & HAS_STANDARD_LAUNCHERS &
                            HAS_ON_OFF_BLOCKS)],
    "Depths Level Clear": [(HAS_STANDARD_SLIDING_BLOCKS & HAS_ON_OFF_BLOCKS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_SLIDING_BLOCKS & HAS_ON_OFF_BLOCKS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_SLIDING_BLOCKS & HAS_ON_OFF_BLOCKS & HAS_STANDARD_LAUNCHERS),
                           (HAS_STANDARD_SLIDING_BLOCKS & HAS_ON_OFF_BLOCKS & HAS_STANDARD_LAUNCHERS)],
    #Cliff Warning
    "Cliff Warning Room 1 Door": [(HAS_STANDARD_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_BLOCK_LAUNCHERS)],
    "Cliff Warning Checkpoint 1": [(HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                    HAS_STANDARD_BUMPERS),
                                   (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                    HAS_STANDARD_BUMPERS),
                                   (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                    HAS_STANDARD_BUMPERS),
                                   (HAS_TIMER_BUTTONS & (HAS_STANDARD_BLOCK_LAUNCHERS |
                                    HAS_STANDARD_BUMPERS))],
    "Cliff Warning Coin 1": [(HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                              HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                              HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                             (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                              HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                              HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                             (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                              HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                              HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                             (HAS_TIMER_BUTTONS & HAS_ON_OFF_BLOCKS &
                              HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS & (
                              HAS_STANDARD_BLOCK_LAUNCHERS | HAS_STANDARD_BUMPERS))],
    "Cliff Warning Level Clear": [(HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                   HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                                   HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                                  (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                   HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                                   HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                                  (HAS_TIMER_BUTTONS & HAS_STANDARD_BLOCK_LAUNCHERS &
                                   HAS_STANDARD_BUMPERS & HAS_ON_OFF_BLOCKS &
                                   HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS),
                                  (HAS_TIMER_BUTTONS & HAS_ON_OFF_BLOCKS &
                                   HAS_STANDARD_PUNCHAPPEAR_BLOCKS & HAS_STANDARD_LAUNCHERS & (
                                   HAS_STANDARD_BLOCK_LAUNCHERS | HAS_STANDARD_BUMPERS))],
    #The Library
    "The Library Tutorial Panel 1": [(HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS)],
    "The Library Tutorial Panel 2": [(HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS)],
    "The Library Tutorial Panel 3": [(HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS),
                                     (HAS_TIMER_BUTTONS)],
    "The Library Room 1 Side Door 1": [(HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS)],
    "The Library Room 1 Side Door 2": [(HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS)],
    "The Library Room 1 Side Door 3": [(HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS)],
    "The Library Coin 1": [(HAS_STANDARD_PHYSICS_BLOCKS),
                           (HAS_STANDARD_PHYSICS_BLOCKS),
                           (HAS_STANDARD_PHYSICS_BLOCKS),
                           (HAS_STANDARD_PHYSICS_BLOCKS)],
    "The Library Coin 2": [(HAS_TIMER_BUTTONS),
                           (HAS_TIMER_BUTTONS),
                           (HAS_TIMER_BUTTONS),
                           (HAS_TIMER_BUTTONS)],
    "The Library Level Clear": [(HAS_TIMER_BUTTONS),
                                (HAS_TIMER_BUTTONS),
                                (HAS_TIMER_BUTTONS),
                                (HAS_TIMER_BUTTONS)],
    #Midnight Grove
    "Midnight Grove Coin 1": [(HAS_BLUE_PEARL_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS)],
    "Midnight Grove Room 1 Door": [(HAS_BLUE_PEARL_LAUNCHERS),
                                   (HAS_BLUE_PEARL_LAUNCHERS),
                                   (HAS_BLUE_PEARL_LAUNCHERS),
                                   (HAS_BLUE_PEARL_LAUNCHERS)],
    "Midnight Grove Coin 2": [(HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                              (HAS_BLUE_PEARL_LAUNCHERS | HAS_PEARL_BLOCK_LAUNCHERS)],
    "Midnight Grove Room 2 Door": [(HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                   (HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                   (HAS_BLUE_PEARL_LAUNCHERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                   (HAS_PEARL_BLOCK_LAUNCHERS)],
    "Midnight Grove Checkpoint 1": [(HAS_RED_PEARL_LAUNCHERS),
                                    (HAS_RED_PEARL_LAUNCHERS),
                                    (HAS_RED_PEARL_LAUNCHERS),
                                    (HAS_RED_PEARL_LAUNCHERS)],
    "Midnight Grove Coin 3": [(HAS_RED_PEARL_LAUNCHERS & HAS_BLUE_PEARL_LAUNCHERS),
                              (HAS_RED_PEARL_LAUNCHERS & HAS_BLUE_PEARL_LAUNCHERS),
                              (HAS_RED_PEARL_LAUNCHERS & (HAS_BLUE_PEARL_LAUNCHERS |
                               HAS_RED_FIRE_RINGS)),
                              (HAS_RED_PEARL_LAUNCHERS & (HAS_BLUE_PEARL_LAUNCHERS |
                               HAS_RED_FIRE_RINGS))],
    "Midnight Grove Room 3 Door": [(HAS_RED_PEARL_LAUNCHERS & HAS_BLUE_PEARL_LAUNCHERS &
                                    HAS_RED_FIRE_RINGS),
                                   (HAS_RED_PEARL_LAUNCHERS & HAS_BLUE_PEARL_LAUNCHERS &
                                    HAS_RED_FIRE_RINGS),
                                   (HAS_RED_PEARL_LAUNCHERS & HAS_RED_FIRE_RINGS),
                                   (HAS_RED_PEARL_LAUNCHERS & HAS_RED_FIRE_RINGS)],
    "Midnight Grove Checkpoint 2": [(HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                     HAS_ARROW_LIFTS),
                                    (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                     HAS_ARROW_LIFTS),
                                    (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS),
                                    (HAS_RED_FIRE_RINGS & (HAS_BLUE_PEARL_LAUNCHERS |
                                     HAS_ARROW_LIFTS))],
    "Midnight Grove Load Bearing Collectible": [(HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                                 HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                                 HAS_LEAD_BALLOONS),
                                                (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                                 HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                                 HAS_LEAD_BALLOONS),
                                                (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                                 HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                                 HAS_LEAD_BALLOONS),
                                                (HAS_RED_FIRE_RINGS & HAS_ARROW_LIFTS &
                                                 HAS_BOMB_FLOWERS)],
    "Midnight Grove Level Clear": [(HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                    HAS_ARROW_LIFTS),
                                   (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                    HAS_ARROW_LIFTS),
                                   (HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS &
                                    HAS_ARROW_LIFTS),
                                   (HAS_RED_FIRE_RINGS & HAS_ARROW_LIFTS)],
    #Briarbrush Woods
    "Briarbrush Woods Room 1 Door": [(HAS_TOGGLE_FLOWERS),
                                     (HAS_TOGGLE_FLOWERS),
                                     (HAS_TOGGLE_FLOWERS),
                                     (HAS_TOGGLE_FLOWERS)],
    "Briarbrush Woods Coin 1": [(HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                (HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                (HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                (HAS_TOGGLE_FLOWERS)],
    "Briarbrush Woods Room 2 Door": [(HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS &
                                      HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS),
                                     (HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS &
                                      HAS_RED_FIRE_RINGS & HAS_BLUE_PEARL_LAUNCHERS),
                                     (HAS_TOGGLE_FLOWERS & HAS_RED_FIRE_RINGS &
                                      HAS_BLUE_PEARL_LAUNCHERS),
                                     (HAS_TOGGLE_FLOWERS & HAS_RED_FIRE_RINGS & 
                                      HAS_BLUE_PEARL_LAUNCHERS)],
    "Briarbrush Woods Room 3 Door": [(HAS_GREEN_BUBBLES & HAS_TOGGLE_FLOWERS),
                                     (HAS_GREEN_BUBBLES & HAS_TOGGLE_FLOWERS),
                                     (HAS_GREEN_BUBBLES & HAS_TOGGLE_FLOWERS),
                                     (HAS_GREEN_BUBBLES & HAS_TOGGLE_FLOWERS)],
    "Briarbrush Woods Level Clear": [(HAS_TOGGLE_FLOWERS & HAS_GREEN_BUBBLES),
                                     (HAS_TOGGLE_FLOWERS),
                                     (HAS_TOGGLE_FLOWERS),
                                     (HAS_TOGGLE_FLOWERS)],
    #Various Explosives
    "Various Explosives Coin 1": [(HAS_RED_BALLOONS & HAS_LEAD_BALLOONS &
                                   HAS_BOMB_FLOWERS),
                                  (HAS_RED_BALLOONS & HAS_LEAD_BALLOONS &
                                   HAS_BOMB_FLOWERS),
                                  (HAS_RED_BALLOONS & HAS_BOMB_FLOWERS),
                                  (HAS_BOMB_FLOWERS)],
    "Various Explosives Room 1 Door": [(HAS_RED_BALLOONS & HAS_LEAD_BALLOONS &
                                        HAS_BOMB_FLOWERS),
                                       (HAS_RED_BALLOONS & HAS_LEAD_BALLOONS &
                                        HAS_BOMB_FLOWERS),
                                       (HAS_RED_BALLOONS & HAS_BOMB_FLOWERS),
                                       (HAS_BOMB_FLOWERS)],
    "Various Explosives Coin 2": [(HAS_BOMB_FLOWERS),
                                  (HAS_BOMB_FLOWERS),
                                  (HAS_BOMB_FLOWERS),
                                  (HAS_BOMB_FLOWERS)],
    "Various Explosives Room 2 Door": [(HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                                        HAS_LEAD_BALLOONS & HAS_RED_BALLOONS),
                                       (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                                        HAS_RED_BALLOONS),
                                       (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS),
                                       (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS)],
    "Various Explosives Coin 3": [(HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                   HAS_TOGGLE_BALLOONS & HAS_LEAD_BALLOONS),
                                  (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                   HAS_TOGGLE_BALLOONS),
                                  (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                   HAS_TOGGLE_BALLOONS),
                                  (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                   HAS_TOGGLE_BALLOONS)],
    "Various Explosives Level Clear": [(HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                        HAS_TOGGLE_BALLOONS & HAS_LEAD_BALLOONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                        HAS_TOGGLE_BALLOONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                        HAS_TOGGLE_BALLOONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_BOMB_FLOWERS &
                                        HAS_TOGGLE_BALLOONS)],
    #Together By Tether
    "Together By Tether Room 1 Door": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_BLUE_PEARL_LAUNCHERS & HAS_BOMB_FLOWERS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_BOMB_FLOWERS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_BOMB_FLOWERS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_BOMB_FLOWERS)],
    "Together By Tether Coin 1": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_BLUE_PEARL_LAUNCHERS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS)],
    "Together By Tether Coin 2": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_BLUE_PEARL_LAUNCHERS & HAS_GREEN_BUBBLES & 
                                   HAS_LEAD_BALLOONS & HAS_RED_BALLOONS &
                                   HAS_RED_FIRE_RINGS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_GREEN_BUBBLES),
                                  (HAS_STANDARD_PHYSICS_BLOCKS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS)],
    "Together By Tether Room 2 Door": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_BLUE_PEARL_LAUNCHERS & HAS_GREEN_BUBBLES &
                                        HAS_RED_FIRE_RINGS & HAS_LEAD_BALLOONS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_RED_FIRE_RINGS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_RED_FIRE_RINGS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS)],
    "Together By Tether Coin 3": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                  (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                   HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS)],
    "Together By Tether Room 3 Door": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                        (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                        (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS),
                                        (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_TOGGLE_FLOWERS & HAS_PEARL_BLOCK_LAUNCHERS)],
    "Together By Tether Level Clear": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                        HAS_LEAD_BALLOONS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS),
                                       (HAS_STANDARD_PHYSICS_BLOCKS)],
    #Pop Unlock
    "Pop Unlock Room 1 Door": [(HAS_GREEN_BUBBLES & HAS_KEY_BUBBLES),
                               (HAS_GREEN_BUBBLES & HAS_KEY_BUBBLES),
                               (HAS_GREEN_BUBBLES & HAS_KEY_BUBBLES),
                               (HAS_GREEN_BUBBLES & HAS_KEY_BUBBLES)],
    "Pop Unlock Coin 1": [(HAS_KEY_BUBBLES & HAS_DIRECTIONAL_BUMPERS &
                           HAS_RED_BALLOONS & HAS_RED_FIRE_RINGS & 
                           HAS_GREEN_BUBBLES & HAS_LEAD_BALLOONS),
                          (HAS_KEY_BUBBLES & HAS_DIRECTIONAL_BUMPERS & (
                           HAS_RED_FIRE_RINGS | HAS_RED_BALLOONS)),
                          (HAS_KEY_BUBBLES & (HAS_RED_BALLOONS | (
                           HAS_DIRECTIONAL_BUMPERS & HAS_RED_FIRE_RINGS))),
                          (HAS_KEY_BUBBLES & (HAS_RED_BALLOONS |
                           HAS_DIRECTIONAL_BUMPERS))],
    "Pop Unlock Room 2 Door": [(HAS_GREEN_BUBBLES & HAS_KEY_BUBBLES &
                                HAS_DIRECTIONAL_BUMPERS & HAS_RED_BALLOONS &
                                HAS_RED_FIRE_RINGS & HAS_LEAD_BALLOONS),
                               (HAS_KEY_BUBBLES & HAS_DIRECTIONAL_BUMPERS & 
                                HAS_RED_FIRE_RINGS & HAS_GREEN_BUBBLES),
                               (HAS_KEY_BUBBLES & (HAS_RED_BALLOONS | (
                                HAS_RED_FIRE_RINGS & (HAS_LEAD_BALLOONS | 
                                HAS_GREEN_BUBBLES)))),
                               (HAS_KEY_BUBBLES & (HAS_RED_BALLOONS | (
                                (HAS_RED_FIRE_RINGS | HAS_DIRECTIONAL_BUMPERS) & (
                                HAS_LEAD_BALLOONS | HAS_GREEN_BUBBLES))))],
    "Pop Unlock Coin 2": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                           HAS_KEY_BUBBLES & HAS_RED_BALLOONS &
                           HAS_PEARL_BLOCK_LAUNCHERS & HAS_TOGGLE_FLOWERS),
                          (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                           HAS_KEY_BUBBLES & HAS_PEARL_BLOCK_LAUNCHERS),
                          (HAS_STANDARD_PHYSICS_BLOCKS & HAS_KEY_BUBBLES & (
                           HAS_TETHERS | HAS_PEARL_BLOCK_LAUNCHERS)),
                          (HAS_STANDARD_PHYSICS_BLOCKS & HAS_KEY_BUBBLES & (
                           HAS_TETHERS | HAS_PEARL_BLOCK_LAUNCHERS))],
    "Pop Unlock Level Clear": [(HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                HAS_KEY_BUBBLES & HAS_RED_BALLOONS &
                                HAS_PEARL_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_PHYSICS_BLOCKS & HAS_TETHERS &
                                HAS_KEY_BUBBLES & HAS_PEARL_BLOCK_LAUNCHERS),
                               (HAS_STANDARD_PHYSICS_BLOCKS & HAS_KEY_BUBBLES),
                               (HAS_STANDARD_PHYSICS_BLOCKS & HAS_KEY_BUBBLES)],
    #The Gatekeeper
    "The Gatekeeper Room 1 Door": [(HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS)],
    "The Gatekeeper Room 2 Door": [(HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS &
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS &
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS &
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS &
                                    HAS_BURNABLE_BLOCKS)],
    "The Gatekeeper Coin 1": [(HAS_ARROW_LIFTS),
                              (HAS_ARROW_LIFTS),
                              (HAS_ARROW_LIFTS),
                              (HAS_ARROW_LIFTS)],
    "The Gatekeeper Coin 2": [(HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS & 
                               HAS_RED_BALLOONS),
                              (HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS & 
                               HAS_RED_BALLOONS),
                              (HAS_GREEN_BUBBLES & (HAS_RED_PEARL_LAUNCHERS |
                               HAS_RED_BALLOONS)),
                              (HAS_GREEN_BUBBLES & (HAS_RED_PEARL_LAUNCHERS |
                               HAS_RED_BALLOONS))],
    "The Gatekeeper Room 3 Door": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES & 
                                    HAS_STANDARD_STAR_BLOCKS & HAS_RED_PEARL_LAUNCHERS & 
                                    HAS_RED_BALLOONS & HAS_ARROW_LIFTS & 
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES & 
                                    HAS_STANDARD_STAR_BLOCKS & HAS_RED_PEARL_LAUNCHERS & 
                                    HAS_RED_BALLOONS & HAS_ARROW_LIFTS & 
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS & HAS_ARROW_LIFTS &
                                    HAS_BURNABLE_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS & HAS_ARROW_LIFTS &
                                    HAS_BURNABLE_BLOCKS)],
    "The Gatekeeper Coin 3": [(HAS_RED_PEARL_LAUNCHERS & HAS_TOGGLE_FLOWERS &
                               HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS &
                               HAS_LEAD_BALLOONS & HAS_RED_BALLOONS),
                              (HAS_RED_PEARL_LAUNCHERS & HAS_TOGGLE_FLOWERS &
                               HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS &
                               HAS_RED_BALLOONS),
                              (HAS_RED_PEARL_LAUNCHERS & HAS_TOGGLE_FLOWERS &
                               HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS),
                              (HAS_TOGGLE_FLOWERS & HAS_GREEN_BUBBLES &
                               HAS_RED_FIRE_RINGS)],
    "The Gatekeeper Room 4 Door": [(HAS_RED_PEARL_LAUNCHERS & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS & HAS_LEAD_BALLOONS &
                                    HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS &
                                    HAS_RED_BALLOONS & HAS_TOGGLE_FLOWERS),
                                   (HAS_RED_PEARL_LAUNCHERS & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS & HAS_GREEN_BUBBLES &
                                    HAS_RED_FIRE_RINGS & HAS_RED_BALLOONS &
                                    HAS_TOGGLE_FLOWERS),
                                   (HAS_RED_PEARL_LAUNCHERS & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS & HAS_GREEN_BUBBLES &
                                    HAS_RED_FIRE_RINGS & HAS_TOGGLE_FLOWERS),
                                   (HAS_NUMBER_BUBBLES & HAS_STANDARD_STAR_BLOCKS &
                                    HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS & 
                                    HAS_TOGGLE_FLOWERS)],
    "The Gatekeeper Heart 1": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS)],
    "The Gatekeeper Heart 2": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS)],
    "The Gatekeeper Heart 3": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS)],
    "The Gatekeeper Heart 4": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS),
                               (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                HAS_STANDARD_STAR_BLOCKS)],
    "The Gatekeeper Level Clear": [(HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS),
                                   (HAS_GREEN_BUBBLES & HAS_NUMBER_BUBBLES &
                                    HAS_STANDARD_STAR_BLOCKS)],
    #The Elevator
    "The Elevator Room 1 Door": [(HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS)],
    "The Elevator Room 2 Door": [(HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS),
                                 (HAS_ARROW_LIFTS)],
    "The Elevator Coin 1": [(HAS_ARROW_LIFTS),
                            (HAS_ARROW_LIFTS),
                            None,
                            None],
    "The Elevator Level Clear": [(HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                  HAS_RED_FIRE_RINGS & HAS_RED_BALLOONS),
                                 (HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                  HAS_RED_FIRE_RINGS),
                                 (HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                  HAS_RED_FIRE_RINGS),
                                 (HAS_ARROW_LIFTS & HAS_BOMB_FLOWERS &
                                  HAS_RED_FIRE_RINGS)],
    #Frostbite
    "Frostbite Room 1 Door": [(HAS_ICE_KEY_BLOCKS & HAS_ICE_BLOCKS &
                               HAS_ICICLES),
                              (HAS_ICE_KEY_BLOCKS & HAS_ICE_BLOCKS),
                              (HAS_ICE_KEY_BLOCKS & HAS_ICE_BLOCKS),
                              (HAS_ICE_KEY_BLOCKS & HAS_ICE_BLOCKS)],
    "Frostbite Room 2 Door": [(HAS_ICE_KEY_BLOCKS & HAS_ICICLES &
                               HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                               HAS_ICE_BLOCKS),
                              (HAS_ICE_KEY_BLOCKS & HAS_ICICLES &
                               HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS),
                              (HAS_ICE_KEY_BLOCKS & HAS_ICICLES &
                               HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS),
                              (HAS_ICE_KEY_BLOCKS & HAS_BOMB_FLOWERS &
                               HAS_TOGGLE_BALLOONS & (HAS_ICE_BLOCKS |
                               HAS_ICICLES))],
    "Frostbite Coin 1": [(HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                          HAS_LEAD_BALLOONS),
                         (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS),
                         (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS),
                         (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS)],
    "Frostbite Room 3 Door": [(HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                               HAS_ICE_KEY_BLOCKS & HAS_ICICLES &
                               HAS_LEAD_BALLOONS),
                              (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                               HAS_ICE_KEY_BLOCKS & HAS_ICICLES),
                              (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                               HAS_ICE_KEY_BLOCKS & HAS_ICICLES),
                              (HAS_BOMB_FLOWERS & HAS_TOGGLE_BALLOONS &
                               HAS_ICE_KEY_BLOCKS & HAS_ICICLES)],
    "Frostbite Checkpoint 1": [(HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS &
                                HAS_ICICLES),
                               (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS),
                               (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS),
                               (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS)],
    "Frostbite Level Clear": [(HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS &
                               HAS_ICICLES & HAS_ICE_KEY_BLOCKS &
                               HAS_RED_PEARL_LAUNCHERS),
                              (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS &
                               HAS_ICE_KEY_BLOCKS & HAS_RED_PEARL_LAUNCHERS),
                              (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS & 
                               HAS_ICE_KEY_BLOCKS),
                              (HAS_ICE_BLOCK_LAUNCHERS & HAS_ICE_BLOCKS)],
    #Forgotten Archives
    "Forgotten Archives Room 1 Door": [(HAS_PEARL_BLOCK_LAUNCHERS & HAS_KEY_QUARTETS &
                                        HAS_TIMER_BUTTONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_KEY_QUARTETS &
                                        HAS_TIMER_BUTTONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_KEY_QUARTETS &
                                        HAS_TIMER_BUTTONS),
                                       (HAS_PEARL_BLOCK_LAUNCHERS & HAS_KEY_QUARTETS &
                                        HAS_TIMER_BUTTONS)],
    "Forgotten Archives Checkpoint 1": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS)],
    "Forgotten Archives Room 2 Door": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS)],
    "Forgotten Archives Coin 1": [(HAS_TIMER_BUTTONS & HAS_GREEN_BUBBLES),
                                  (HAS_TIMER_BUTTONS),
                                  (HAS_TIMER_BUTTONS),
                                  (HAS_TIMER_BUTTONS)],
    "Forgotten Archives Room 3 Door": [(HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS),
                                       (HAS_TIMER_BUTTONS)],
    "Forgotten Archives Load Bearing Collectible": [(HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                                     HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS &
                                                     HAS_LEAD_BALLOONS & HAS_RED_FIRE_RINGS &
                                                     HAS_RED_BALLOONS),
                                                    (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                                     HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS &
                                                     HAS_RED_FIRE_RINGS & HAS_RED_BALLOONS),
                                                    (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                                     HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS &
                                                     HAS_RED_FIRE_RINGS & HAS_RED_BALLOONS),
                                                    (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                                     HAS_GREEN_BUBBLES & HAS_RED_PEARL_LAUNCHERS &
                                                     HAS_RED_FIRE_RINGS & HAS_RED_BALLOONS)],
    "Forgotten Archives Room 4 Door": [(HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                        HAS_GREEN_BUBBLES & HAS_RED_FIRE_RINGS & 
                                        HAS_DIRECTIONAL_BUMPERS),
                                       (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                        HAS_RED_FIRE_RINGS & HAS_DIRECTIONAL_BUMPERS),
                                       (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                        HAS_RED_FIRE_RINGS & HAS_DIRECTIONAL_BUMPERS),
                                       (HAS_TIMER_BUTTONS & HAS_KEY_BUBBLES &
                                        HAS_RED_FIRE_RINGS & HAS_DIRECTIONAL_BUMPERS)],
    "Forgotten Archives Checkpoint 2": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS)],
    "Forgotten Archives Checkpoint 3": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                        (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS)],
    "Forgotten Archives Coin 2": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                   HAS_RED_BALLOONS),
                                  (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                   HAS_RED_BALLOONS),
                                  (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS),
                                  (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS)],
    "Forgotten Archives Level Clear": [(HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS & HAS_RED_FIRE_RINGS &
                                        HAS_LEAD_BALLOONS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS & HAS_RED_FIRE_RINGS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS & HAS_RED_FIRE_RINGS),
                                       (HAS_GREEN_BUBBLES & HAS_TIMER_BUTTONS &
                                        HAS_KEY_QUARTETS & HAS_RED_FIRE_RINGS)],
    #The Scenic Route
    "The Scenic Route Room 1 Door": [(HAS_RED_BALLOONS & HAS_SNAKE_BLOCKS &
                                      HAS_RED_FIRE_RINGS & HAS_GREEN_BUBBLES &
                                      HAS_LEAD_BALLOONS & HAS_BOMB_FLOWERS),
                                     (HAS_RED_BALLOONS & HAS_SNAKE_BLOCKS &
                                      HAS_RED_FIRE_RINGS & HAS_GREEN_BUBBLES &
                                      HAS_LEAD_BALLOONS & HAS_BOMB_FLOWERS),
                                     (HAS_RED_BALLOONS & HAS_SNAKE_BLOCKS &
                                      HAS_RED_FIRE_RINGS),
                                     (HAS_RED_BALLOONS & HAS_SNAKE_BLOCKS &
                                      HAS_RED_FIRE_RINGS)],
    "The Scenic Route Checkpoint 1": [(HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                       HAS_PEARL_BLOCK_LAUNCHERS & HAS_RED_BALLOONS),
                                      (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                       HAS_PEARL_BLOCK_LAUNCHERS),
                                      (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                       HAS_PEARL_BLOCK_LAUNCHERS),
                                      (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS)],
    "The Scenic Route Room 2 Door": [(HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                      HAS_PEARL_BLOCK_LAUNCHERS & HAS_RED_BALLOONS &
                                      HAS_ARROW_LIFTS & HAS_GREEN_BUBBLES),
                                     (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                      HAS_PEARL_BLOCK_LAUNCHERS & HAS_ARROW_LIFTS & 
                                      HAS_GREEN_BUBBLES),
                                     (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                      HAS_PEARL_BLOCK_LAUNCHERS & HAS_ARROW_LIFTS &
                                      HAS_GREEN_BUBBLES),
                                     (HAS_BLUE_FIRE_RINGS & HAS_SNAKE_BLOCKS &
                                      HAS_ARROW_LIFTS & HAS_GREEN_BUBBLES)],
    "The Scenic Route Room 3 Door": [(HAS_BLUE_FIRE_RINGS & HAS_RED_PEARL_LAUNCHERS &
                                      HAS_BOMB_FLOWERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_RED_PEARL_LAUNCHERS &
                                      HAS_BOMB_FLOWERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_RED_PEARL_LAUNCHERS &
                                      HAS_BOMB_FLOWERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_RED_PEARL_LAUNCHERS &
                                      HAS_BOMB_FLOWERS)],
    "The Scenic Route Room 4 Door": [(HAS_BLUE_FIRE_RINGS & HAS_STANDARD_PHYSICS_BLOCKS &
                                      HAS_TETHERS & HAS_LEAD_BALLOONS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_STANDARD_PHYSICS_BLOCKS &
                                      HAS_TETHERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_STANDARD_PHYSICS_BLOCKS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_STANDARD_PHYSICS_BLOCKS)],
    "The Scenic Route Room 5 Door": [(HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                      HAS_YELLOW_BLOCK_LAUNCHERS),
                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                      HAS_YELLOW_BLOCK_LAUNCHERS),
                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                      HAS_YELLOW_BLOCK_LAUNCHERS),
                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "The Scenic Route Room 6 Door": [(HAS_BLUE_FIRE_RINGS & HAS_GLASS_BLOCKS &
                                      HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_SWITCHES & 
                                      HAS_STANDARD_POP_BLOCKS & HAS_BLUE_CRYSTAL_LAUNCHERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_GLASS_BLOCKS &
                                      HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_SWITCHES &
                                      HAS_STANDARD_POP_BLOCKS & HAS_BLUE_CRYSTAL_LAUNCHERS),
                                     (HAS_BLUE_FIRE_RINGS & HAS_GLASS_BLOCKS &
                                      HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_SWITCHES &
                                      HAS_STANDARD_POP_BLOCKS & HAS_BLUE_CRYSTAL_LAUNCHERS),
                                     (HAS_BLUE_FIRE_RINGS & (HAS_STANDARD_POP_BLOCKS | (
                                      HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_SWITCHES)) &
                                      HAS_BLUE_CRYSTAL_LAUNCHERS)],
    "The Scenic Route Coin 1": [(HAS_YELLOW_SKULL_RINGS),
                                None,
                                None,
                                None],
    "The Scenic Route Level Clear": [HAS_YELLOW_SKULL_RINGS,
                                     None,
                                     None,
                                     None],
    #The Timeless Temple
    "The Timeless Temple Room 1 Door": [(HAS_YELLOW_PHYSICS_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                        (HAS_YELLOW_PHYSICS_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                        (HAS_YELLOW_PHYSICS_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "The Timeless Temple Room 2 Door": [(HAS_YELLOW_SKULL_RINGS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS & 
                                         HAS_YELLOW_SKULL_BLOCKS),
                                        (HAS_YELLOW_SKULL_RINGS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "The Timeless Temple Coin 1": [(HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                    HAS_YELLOW_SKULL_RINGS),
                                   (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS),
                                   (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS),
                                   (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "The Timeless Temple Load Bearing Collectible": [(HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                                      HAS_YELLOW_SKULL_RINGS & HAS_YELLOW_VIVI_BLOCKS),
                                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                                      HAS_YELLOW_VIVI_BLOCKS),
                                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS &
                                                      HAS_YELLOW_VIVI_BLOCKS),
                                                     (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_VIVI_BLOCKS)],
    "The Timeless Temple Level Clear": [(HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS & 
                                         HAS_YELLOW_SKULL_RINGS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_BLOCKS),
                                        (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    #Haunted Halls
    "Haunted Halls Room 1 Door": [(HAS_YELLOW_GORBS & HAS_YELLOW_PHYSICS_BLOCKS &
                                   HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_SKULL_RINGS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_GORBS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "Haunted Halls Coin 1": [(HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS &
                              HAS_YELLOW_GORBS & HAS_YELLOW_SKULL_BLOCKS),
                             (HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS &
                              HAS_YELLOW_GORBS & HAS_YELLOW_SKULL_BLOCKS),
                             (HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                             (HAS_YELLOW_SLIDING_BLOCKS)],
    "Haunted Halls Room 2 Door": [(HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS & 
                                   HAS_YELLOW_SKULL_BLOCKS & HAS_YELLOW_GORBS),
                                  (HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS & 
                                   HAS_YELLOW_SKULL_BLOCKS & HAS_YELLOW_GORBS),
                                  (HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS & 
                                   HAS_YELLOW_SKULL_BLOCKS),
                                  (HAS_YELLOW_SLIDING_BLOCKS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "Haunted Halls Room 3 Door": [(HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_BLOCK_LAUNCHERS &
                                   HAS_YELLOW_GORBS & HAS_YELLOW_SKULL_BLOCKS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_BLOCK_LAUNCHERS &
                                   HAS_YELLOW_GORBS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS & HAS_YELLOW_BLOCK_LAUNCHERS),
                                  (HAS_YELLOW_PUNCHAPPEAR_BLOCKS)],
    "Haunted Halls Level Clear": [(HAS_YELLOW_BUMPERS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS &
                                   HAS_YELLOW_GORBS & HAS_YELLOW_SKULL_BLOCKS),
                                  (HAS_YELLOW_BUMPERS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS &
                                   HAS_YELLOW_GORBS),
                                  (HAS_YELLOW_BUMPERS & HAS_YELLOW_PUNCHAPPEAR_BLOCKS),
                                  None],
    #Borrowed Time
    "Borrowed Time Room 1 Door": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Borrowed Time Coin 1": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                              HAS_BLUE_SKULL_BLOCKS),
                             (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                             (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                             (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Borrowed Time Room 2 Door": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Borrowed Time Room 3 Door": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                   HAS_BLUE_SKULL_RINGS & HAS_BLUE_SKULL_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                  (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Borrowed Time Level Clear": [(HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                   HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                  (HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                   HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                  (HAS_CLEAR_BUBBLES),
                                  (HAS_CLEAR_BUBBLES)],
    #Nyctophobia
    "Nyctophobia Coin 1": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                           (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                           (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                           (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Nyctophobia Room 1 Door": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Nyctophobia Coin 2": [(HAS_CLEAR_BUBBLES),
                           (HAS_CLEAR_BUBBLES),
                           (HAS_CLEAR_BUBBLES),
                           (HAS_CLEAR_BUBBLES)],
    "Nyctophobia Room 2 Door": [(HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                 HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                 HAS_BLUE_PUNCHAPPEAR_BLOCKS & HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                 HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                (HAS_CLEAR_BUBBLES & HAS_BLUE_SWITCHES &
                                 HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Nyctophobia Coin 3": [(HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS),
                           (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS),
                           (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS),
                           (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS)],
    "Nyctophobia Room 3 Door": [(HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS &
                                 HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS &
                                 HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS),
                                (HAS_CLEAR_BUBBLES & HAS_GLASS_BLOCKS)],
    "Nyctophobia Checkpoint 1": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                  HAS_CLEAR_BUBBLES & HAS_BLUE_SKULL_RINGS),
                                 (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                  HAS_CLEAR_BUBBLES),
                                 (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                  HAS_CLEAR_BUBBLES),
                                 None],
    "Nyctophobia Coin 4": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                            HAS_CLEAR_BUBBLES & HAS_BLUE_SKULL_RINGS &
                            HAS_STANDARD_POP_BLOCKS),
                           (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                            HAS_CLEAR_BUBBLES),
                           (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                            HAS_CLEAR_BUBBLES),
                           (None)],
    "Nyctophobia Room 4 Door": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                  HAS_CLEAR_BUBBLES & HAS_BLUE_SKULL_RINGS &
                                  HAS_STANDARD_POP_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                 HAS_CLEAR_BUBBLES & HAS_STANDARD_POP_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                 HAS_CLEAR_BUBBLES & HAS_STANDARD_POP_BLOCKS),
                                (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                 HAS_STANDARD_POP_BLOCKS)],
    "Nyctophobia Coin 5": [(HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES),
                           (HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES),
                           (HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES),
                           (HAS_BLUE_GORBS)],
    "Nyctophobia Level Clear": [(HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES &
                                 HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES &
                                 HAS_BLUE_BLOCK_LAUNCHERS),
                                (HAS_BLUE_GORBS & HAS_CLEAR_BUBBLES),
                                (HAS_BLUE_GORBS & (HAS_CLEAR_BUBBLES |
                                 HAS_BLUE_BLOCK_LAUNCHERS))],
    #Shifting Walls
    "Shifting Walls Room 1 Door": [(HAS_STANDARD_POP_BLOCKS),
                                   (HAS_STANDARD_POP_BLOCKS),
                                   (HAS_STANDARD_POP_BLOCKS),
                                   None],
    "Shifting Walls Room 2 Door": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                    HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                    HAS_BLUE_SLIDING_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                    HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                                    HAS_BLUE_SLIDING_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                    HAS_BLUE_SLIDING_BLOCKS),
                                   None],
    "Shifting Walls Checkpoint 1": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                    (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                    (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                    (HAS_GLASS_BLOCKS)],
    "Shifting Walls Coin 1": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                              (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                              (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                              (HAS_GLASS_BLOCKS)],
    "Shifting Walls Room 3 Door": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                   (HAS_GLASS_BLOCKS)],
    "Shifting Walls Coin 2": [(HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                               HAS_STANDARD_POP_BLOCKS & HAS_BLUE_SKULL_BLOCKS),
                              (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS & 
                               HAS_STANDARD_POP_BLOCKS),
                              (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS &
                               HAS_STANDARD_POP_BLOCKS),
                              (HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS)],
    "Shifting Walls Checkpoint 2": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                     HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                    (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                     HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                    (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                    (HAS_GLASS_BLOCKS)],
    "Shifting Walls Level Clear": [(HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                    HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS &
                                    HAS_BLUE_SWITCHES & HAS_BLUE_PUNCHAPPEAR_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS),
                                   (HAS_GLASS_BLOCKS & HAS_STANDARD_POP_BLOCKS)],
}