from dataclasses import dataclass

from Options import Choice, OptionGroup, PerGameCommonOptions, Range, Toggle

class Goal(Choice):
    """
    The goal of the game.
    Vanilla means the goal is to beat the World 5 boss.
    Universal Bearing Collectable means the goal is to beat the secret exit in The Looking Glass.
    Home means the goal is to beat home after collecting the Universal Bearing Collectable.
    Home will be treated as the first secret exit if the goal is not Home.
    """

    display_name = "Goal"

    option_vanilla = 0
    option_universal_bearing_collectable = 1
    option_home = 2

    default = option_vanilla

class Difficulty(Choice):
    """
    What tricks will be factored into the game's logic.
    Intended means that if an item makes a level easier in any way, it is required for logic.
    Simple means that easily skipable items will not be required for logic.
    Advanced means that any skipable items will not required for logic.
    Glitched means that any skipable items including glitches will not be required for logic.
    """

    display_name = "Difficulty"

    option_intended = 0
    option_simple = 1
    option_advanced = 2
    option_glitched = 3

    default = option_simple

class OpenWorld(Choice):
    """
    How open the world is.
    Closed means each level is unlocked individually.
    Partial means standard exits are unlocked at the start.
    Boss and Secret exits still need to be unlocked.
    Open means that everything besides boss exits are unlocked at the start.
    The Scenic Route's exit is also an exception.
    Full means that all exits are unlocked at the start.
    """

    display_name = "Open World"

    option_closed = 0
    option_partial = 1
    option_open = 2
    option_full = 3

    default = option_open

class Paths(Choice):
    """
    How are Paths between levels unlocked.
    Vanilla means that beating a level will unlock its corresponding path.
    Random means that each level path will be an item in the pool.
    Progressive means that progressive path items will be added to the pool.
    While normal paths will be unlocked with Progressive Paths, 
    paths to and from secret levels will be unlocked with Progressive Secret Paths.
    """

    display_name = "Paths"

    option_vanilla = 0
    option_random = 1
    option_progressive = 2

    default = option_progressive

class EntranceRando(Toggle):
    """
    Should level entrances be randomized.
    """

    display_name = "Entrance Rando"

class DoorRando(Choice):
    """
    Should doors in levels be randomized.
    Two way doors are always excluded from door rando.
    Full means that any door can lead to any other door.
    Balanced means that any door can lead to any other door,
    but levels will always have the same number of rooms as they had originaly.
    Restricted means that doors can lead to any other door in the same level.
    Disabled means that doors will not be randomized.
    """

    display_name = "Door Rando"

    option_full = 0
    option_balanced = 1
    option_restricted = 2
    option_disabled = 3

class Roomsanity(Toggle):
    """
    Adds each room as a location.
    This adds 209 locations so enable this with caution.
    """

    display_name = "Roomsanity"

class Checkpointsanity(Toggle):
    """
    Adds each checkpoint as a location.
    This adds 41 locations.
    """

    display_name = "Checkpointsanity"

class MaxCoinAmount(Range):
    """
    How many coins can be added to the item pool.
    The number of coins actually added to the item pool may be lower if there are not enough locations.
    """

    display_name = "Max Coin Amount"

    range_start = 0
    range_end = 500

    default = 100

class FirstSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the first secret exit.
    """

    display_name = "First Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 10

class SecondSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the second secret exit.
    """

    display_name = "Second Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 20

class ThirdSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the third secret exit.
    """

    display_name = "Third Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 30

class FourthSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the fourth secret exit.
    """

    display_name = "Fourth Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 40

class FifthSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the fifth secret exit.
    """

    display_name = "Fifth Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 50

class SixthSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the sixth secret exit.
    """

    display_name = "Sixth Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 60

class SeventhSecretExitCoinRequirement(Range):
    """
    What percentage of coins are needed to access the seventh secret exit.
    """

    display_name = "Seventh Secret Exit Coin Requirement"

    range_start = 0
    range_end = 100

    default = 70

class FirstBossCoinRequirement(Range):
    """
    What percentage of coins are needed to access the first boss level.
    """

    display_name = "First Boss Coin Requirement"

    range_start = 0
    range_end = 100

    default = 5

class SecondBossCoinRequirement(Range):
    """
    What percentage of coins are needed to access the second boss level.
    """

    display_name = "Second Boss Coin Requirement"

    range_start = 0
    range_end = 100

    default = 10

class ThirdBossCoinRequirement(Range):
    """
    What percentage of coins are needed to access the third boss level.
    """

    display_name = "Third Boss Coin Requirement"

    range_start = 0
    range_end = 100

    default = 20

class FourthBossCoinRequirement(Range):
    """
    What percentage of coins are needed to access the fourth boss level.
    """

    display_name = "Fourth Boss Coin Requirement"

    range_start = 0
    range_end = 100

    default = 40

class FifthBossCoinRequirement(Range):
    """
    What percentage of coins are needed to access the fifth boss level.
    """

    display_name = "Fifth Boss Coin Requirement"

    range_start = 0
    range_end = 100

    default = 70

class DefaultItemGroups(Choice):
    """
    How items will be grouped together by default.
    To use Pop Blocks as an example:
    Seperated item groups means Standard Pop Blocks and Galactic Pop Blocks will be added to the pool.
    Collecting each one will unlock its corresponding item.
    Progressive item groups means two Progressive Pop Blocks will be added to the pool.
    Collecting the first will unlock Standard Pop Blocks, and the second will unlock Galactic Pop Blocks.
    Grouped item groups means Pop Blocks will be added to the pool.
    Collecting it will unlock both Standard Pop Blocks and Galactic Pop Blocks.
    Precollected item groups means no items will be added to the pool.
    Both Standard Pop Blocks and Galactic Pop Blocks will be unlocked from the start.
    """

    display_name = "Default Item Groups"

    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_seperated

class DefaultExtraItems(Choice):
    """
    Whether or not extra items are included by default.
    How these extra items are added is dependent on the item's grouping.
    To use Skull Rings as an example:
    Seperated item groups will have two Yellow Skull Rings, and two Blue Skull Rings in the pool.
    Collecting the first of each will let you stop the corresponding Skull Ring from moving.
    Collecting the second of each will neutralize the corresponding Skull Ring.
    Progressive item groups will add a third additional Progressive Skull Ring to the pool.
    Collecting the third Progressive Skull Ring will neutralize both types of Skull Rings.
    Grouped item groups will add a second additional Skull Rings to the pool.
    Collecting the second Skull Rings will neutralize both types of Skull Rings.
    Precollected item groups means no items will be added to the pool.
    Both types of Skull Rings will be neutralized from the start.
    """

    display_name = "Default Extra Items"

    option_enabled = 1
    option_disabled = 2

    default = option_enabled

class DestructibleBlocks(Choice):
    """
    Progressive order is:
    Smash Blocks -> Burnable Blocks -> Snake Blocks
    """

    display_name = "Destructible Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class PhysicsBlocks(Choice):
    """
    Progressive order is:
    Standard Physics Blocks -> Ice Blocks -> Yellow Physics Blocks ->
    Concrete Blocks -> Electric Blocks -> Line Blocks
    """

    display_name = "Physics Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class SlidingBlocks(Choice):
    """
    Progressive order is:
    Standard Sliding Blocks -> Yellow Sliding Blocks -> Blue Sliding Blocks ->
    Crystal Sliding Blocks -> Galactic Sliding Blocks
    """

    display_name = "Sliding Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class BossBlocks(Choice):
    """
    Progressive order is:
    Standard Star Blocks -> Yellow Star Blocks -> Blue Star Blocks ->
    Standard Heart Blocks -> Sliding Heart Blocks -> Delayed Heart Blocks
    """

    display_name = "Boss Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class PopBlocks(Choice):
    """
    Progressive order is:
    Standard Pop Blocks -> Galactic Pop Blocks
    """

    display_name = "Pop Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Bumpers(Choice):
    """
    Progressive order is:
    Standard Bumpers -> Directional Bumpers -> 
    Yellow Bumpers -> Black Hole Bumpers
    """

    display_name = "Bumpers"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Switches(Choice):
    """
    Progressive order is:
    Blue Switches -> Orange Switches
    """

    display_name = "Switches"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class PunchappearBlocks(Choice):
    """
    Progressive order is:
    Standard Punchappear Blocks -> Yellow Punchappear Blocks ->
    Blue Punchappear Blocks -> Orange Punchappear Blocks
    """

    display_name = "Punchappear Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class SkullBlocks(Choice):
    """
    Progressive order is:
    Yellow Skull Blocks -> Blue Skull Blocks -> Orange Skull Blocks
    """

    display_name = "Skull Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class ExtraSkullBlocks(Choice):
    """
    Include extra Skull Block items to disable them.
    """

    display_name = "Extra Skull Blocks"

    option_default = 0
    option_enabled = 1
    option_disabled = 2
    
    default = option_default

class SkullRings(Choice):
    """
    Progressive order is:
    Yellow Skull Rings -> Blue Skull Rings
    """

    display_name = "Skull Rings"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class ExtraSkullRings(Choice):
    """
    Include extra Skull Ring items to disable them.
    """

    display_name = "Extra Skull Rings"

    option_default = 0
    option_enabled = 1
    option_disabled = 2
    
    default = option_default

class Enemies(Choice):
    """
    Progressive order is:
    Gubes -> Yellow Gorbs -> Blue Gorbs -> Pixies
    """

    display_name = "Enemies"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class ExtraEnemies(Choice):
    """
    Include extra Enemy items to disable them.
    """

    display_name = "Extra Enemies"

    option_default = 0
    option_enabled = 1
    option_disabled = 2
    
    default = option_default

class ViviBlocks(Choice):
    """
    Progressive order is:
    Standard Vivi Blocks -> Yellow Vivi Blocks -> Firework Vivi Blocks
    """

    display_name = "Vivi Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class BlockLaunchers(Choice):
    """
    Progressive order is:
    Standard Block Launchers -> Wing Block Launchers -> Pearl Block Launchers ->
    Ice Block Launchers -> Yellow Block Launchers -> Blue Block Launchers ->
    Inverted Block Launchers -> Galactic Block Launchers -> Fire Block Launchers
    """

    display_name = "Block Launchers"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Launchers(Choice):
    """
    Progressive order is:
    Standard Launchers -> Blue Pearl Launchers -> Red Pearl Launchers ->
    Yellow Crystal Launchers -> Blue Crystal Launchers -> Moon Launchers
    """

    display_name = "Launchers"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Hazards(Choice):
    """
    Progressive order is:
    Standard Spinners -> Star Spinners ->
    Red Fire Rings -> Blue Fire Rings
    """

    display_name = "Hazards"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class ExtraHazards(Choice):
    """
    Include extra Hazard items to disable them.
    """

    display_name = "Extra Hazards"

    option_default = 0
    option_enabled = 1
    option_disabled = 2
    
    default = option_default

class Bubbles(Choice):
    """
    Progressive order is:
    Green Bubbles -> Key Bubbles -> Number Bubbles ->
    Clear Bubbles -> Honey Bubbles
    """

    display_name = "Bubbles"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Balloons(Choice):
    """
    Progressive order is:
    Red Balloons -> Blue Balloons ->
    Lead Balloons -> Toggle Balloons
    """

    display_name = "Balloons"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Bombs(Choice):
    """
    Progressive order is:
    Bomb Flowers -> Bomb Blocks -> Hive Bombs
    """

    display_name = "Bombs"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class HiveBlocks(Choice):
    """
    Progressive order is:
    Blue Hive Blocks -> Red Hive Blocks
    """

    display_name = "Hive Blocks"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Keys(Choice):
    """
    Progressive order is:
    Standard Key Blocks -> Key Quartets ->
    Ice Key Blocks -> Inverted Key Blocks
    """

    display_name = "Keys"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class GravityItems(Choice):
    """
    Progressive order is:
    Up Gravity Flippers -> Down Gravity Flippers -> Up Gravity Fields ->
    Down Gravity Fields -> Up Water -> Down Water ->
    Gravity Fists -> Gravity Anchors
    """

    display_name = "Gravity Items"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Lifts(Choice):
    """
    Progressive order is:
    Arrow Lifts -> Yellow Lifts -> Hive Lifts
    """

    display_name = "Lifts"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class Semisolids(Choice):
    """
    Progressive order is:
    Standard Semisolids -> Inverted Semisolids -> Toggle Semisolids
    """

    display_name = "Semisolids"

    option_default = 0
    option_seperated = 1
    option_progressive = 2
    option_grouped = 3
    option_precollected = 4

    default = option_default

class VivisFlashlight(Choice):
    """
    Include Vivi's Flashlight as an extra item which lights up Nyctophobia.
    """

    display_name = "Vivi's Flashlight"

    option_default = 0
    option_enabled = 1
    option_disabled = 2
    
    default = option_default

@dataclass
class FantasticFistOptions(PerGameCommonOptions):
    goal: Goal
    difficulty: Difficulty
    open_world: OpenWorld
    paths: Paths
    entrance_rando: EntranceRando
    door_rando: DoorRando
    roomsanity: Roomsanity
    checkpointsanity: Checkpointsanity
    max_coin_amount: MaxCoinAmount
    first_secret_exit_coin_requirement: FirstSecretExitCoinRequirement
    second_secret_exit_coin_requirement: SecondSecretExitCoinRequirement
    third_secret_exit_coin_requirement: ThirdSecretExitCoinRequirement
    fourth_secret_exit_coin_requirement: FourthSecretExitCoinRequirement
    fifth_secret_exit_coin_requirement: FifthSecretExitCoinRequirement
    sixth_secret_exit_coin_requirement: SixthSecretExitCoinRequirement
    seventh_secret_exit_coin_requirement: SeventhSecretExitCoinRequirement
    first_boss_coin_requirement: FirstBossCoinRequirement
    second_boss_coin_requirement: SecondBossCoinRequirement
    third_boss_coin_requirement: ThirdBossCoinRequirement
    fourth_boss_coin_requirement: FourthBossCoinRequirement
    fifth_boss_coin_requirement: FifthBossCoinRequirement
    default_item_groups: DefaultItemGroups
    default_extra_items: DefaultExtraItems
    destructible_blocks: DestructibleBlocks
    physics_blocks: PhysicsBlocks
    sliding_blocks: SlidingBlocks
    boss_blocks: BossBlocks
    pop_blocks: PopBlocks
    bumpers: Bumpers
    switches: Switches
    punchappear_blocks: PunchappearBlocks
    skull_blocks: SkullBlocks
    extra_skull_blocks: ExtraSkullBlocks
    skull_rings: SkullRings
    extra_skull_rings: ExtraSkullRings
    enemies: Enemies
    extra_enemies: ExtraEnemies
    vivi_blocks: ViviBlocks
    block_launchers: BlockLaunchers
    launchers: Launchers
    hazards: Hazards
    extra_hazards: ExtraHazards
    bubbles: Bubbles
    balloons: Balloons
    bombs: Bombs
    hive_blocks: HiveBlocks
    keys: Keys
    gravity_items: GravityItems
    lifts: Lifts
    semisolids: Semisolids
    vivis_flashlight: VivisFlashlight