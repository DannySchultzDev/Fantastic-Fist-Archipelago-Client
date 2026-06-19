from collections.abc import Mapping
from typing import Any

from worlds.AutoWorld import World

from . import items, locations, regions, rules#, web_world
from . import options as yaml_options

class FantasticFistWorld(World):
    """
    Fantastic Fist is a 2D platformer which uses both keyboard and mouse controls.
    """

    game = "Fantastic Fist"

    #web = web_world.FantasticFistWebWorld()

    options_dataclass = yaml_options.FantasticFistOptions
    options: yaml_options.FantasticFistOptions

    location_name_to_id = locations.LOCATION_NAME_TO_ID
    item_name_to_id = items.ITEM_NAME_TO_ID

    origin_region_name = "Menu"

    randomized_entrances: list[regions.Edge] = []
    randomized_doors: list[regions.Edge] = []

    def create_regions(self) -> None:
        regions.create_and_connect_regions(self)
        locations.create_all_locations(self)

    def set_all_rules(self) -> None:
        rules.set_all_rules(self)

    def create_items(self) -> None:
        items.create_all_items(self)

    def create_item(self, name: str) -> items.FantasticFistItem:
        return items.create_item_with_correct_classification(self, name)
    
    def get_filler_item_name(self) -> str:
        return items.get_random_filler_item_name(self)
    
    def fill_slot_data(self) -> Mapping[str, Any]:
        return self.options.as_dict(
            "goal"
        )