from __future__ import annotations

from typing import TYPE_CHECKING

from typing import NamedTuple

from BaseClasses import Entrance, Region

if TYPE_CHECKING:
    from .world import FantasticFistWorld

class Node(NamedTuple):
    node_name: str
    node_type: str
    level_id: int

class Edge(NamedTuple):
    start_node: Node
    end_node: Node
    double_sided: bool

class Level(NamedTuple):
    level_id: str
    level_name: str
    level_room_count: int

ID_TO_LEVEL = {
    0: Level("1-1", "Introduction", 4),
    1: Level("1-2", "The Caves", 4),
    2: Level("1-3", "Get A Grip", 3),
    3: Level("1-4", "Verticality", 5),
    4: Level("1-5", "Catch A Ride", 4),
    5: Level("1-6", "Chaos Cavern", 3),
    6: Level("1-7", "Holding On", 4),
    7: Level("1-8", "Fist Fight", 6),
    8: Level("1-A", "Depths", 3),
    9: Level("1-B", "Cliff Warning", 2),
    10: Level("1-C", "The Library", 4),
    11: Level("2-1", "Midnight Grove", 4),
    12: Level("2-2", "Briarbrush Woods", 4),
    13: Level("2-3", "Various Explosives", 3),
    14: Level("2-4", "Together By Tether", 4),
    15: Level("2-5", "Pop Unlock", 3),
    16: Level("2-6", "The Gatekeeper", 5),
    17: Level("2-A", "The Elevator", 3),
    18: Level("2-B", "Frostbite", 4),
    19: Level("2-C", "Forgotten Archives", 5),
    20: Level("2-D", "The Scenic Route", 7),
    21: Level("3-1", "The Timeless Temple", 3),
    22: Level("3-2", "Haunted Halls", 4),
    23: Level("3-3", "Borrowed Time", 4),
    24: Level("3-4", "Nyctophobia", 5),
    25: Level("3-5", "Shifting Walls", 4),
    26: Level("3-6", "Skullduggery", 5),
    27: Level("3-7", "The Throne Room", 11),
    28: Level("3-A", "Pop To The Top", 3),
    29: Level("3-B", "Periodic Prison", 4),
    30: Level("4-1", "Infinity Garden", 3),
    31: Level("4-2", "Autumnal Aether", 3),
    32: Level("4-3", "Among The Stars", 4),
    33: Level("4-4", "Den Of Pixies", 4),
    34: Level("4-5", "Heels Over Head", 4),
    35: Level("4-6", "The Hive", 7),
    36: Level("4-7", "The Five Mile Spire", 9),
    37: Level("4-8", "Gube Gardens", 5),
    38: Level("4-9", "The Golf Fungus", 11),
    39: Level("4-A", "Over The Woods", 3),
    40: Level("5-1", "Welcome To The Void", 5),
    41: Level("5-2", "The Sky Is Falling", 5),
    42: Level("5-3", "The Looking Glass", 9),
    43: Level("5-4", "Galactic Central Point", 6),
    44: Level("1-0", "Home", 6)
}

def create_and_connect_regions(world: FantasticFistWorld) -> None:
    nodes: list[Node] = []
    edges: list[Edge] = []
    create_world_map(world, nodes, edges)
    create_first_rooms(world, nodes, edges)
    create_rooms(world, nodes, edges)
    create_all_regions(world, nodes)
    connect_regions(world, edges)

def get_node_from_name(nodes: list[Node], name: str) -> Node:
    for node in nodes:
        if node.node_name == name:
            return node
    return None

def get_nodes_from_type(nodes: list[Node], type: str) -> list[Node]:
    nodes_of_type: list[Node] = []
    for node in nodes:
        if node.node_type == type:
            nodes_of_type.append(node)
    return nodes_of_type

def pop_nodes_from_type(nodes: list[Node], type: str) -> list[Node]:
    nodes_of_type = get_nodes_from_type(nodes, type)
    for node_of_type in nodes_of_type:
        nodes.remove(node_of_type)
    return nodes_of_type

def append_room_number (name: str, room_number: int) -> str:
    return name + " Room " + str(room_number)

def create_world_map(world: FantasticFistWorld, nodes: list[Node], edges: list[Edge]):
    #Levels to Nodes
    new_nodes: list[Node] = []
    for level in ID_TO_LEVEL.values():
        new_nodes.append(Node(level.level_id, "Level", -1))

    nodes.extend(new_nodes)

    #Standard Paths to Edges
    for k in range(7):
        edges.append(Edge(new_nodes[k + 0], new_nodes[k + 1], True))

    for k in range(5):
        edges.append(Edge(new_nodes[k + 11], new_nodes[k + 12], True))

    for k in range(6):
        edges.append(Edge(new_nodes[k + 21], new_nodes[k + 22], True))

    for k in range(8):
        edges.append(Edge(new_nodes[k + 30], new_nodes[k + 31], True))

    for k in range(3):
        edges.append(Edge(new_nodes[k + 40], new_nodes[k + 41], True))

    #World Paths to Edges
    edges.append(Edge(new_nodes[7], new_nodes[11], True))
    edges.append(Edge(new_nodes[16], new_nodes[21], True))
    edges.append(Edge(new_nodes[27], new_nodes[30], True))
    edges.append(Edge(new_nodes[38], new_nodes[40], True))

    #Secret Paths to Edges
    edges.append(Edge(new_nodes[0], new_nodes[44], True))
    edges.append(Edge(new_nodes[1], new_nodes[8], True))
    edges.append(Edge(new_nodes[8], new_nodes[9], True))
    edges.append(Edge(new_nodes[9], new_nodes[4], True))
    edges.append(Edge(new_nodes[3], new_nodes[10], True))
    edges.append(Edge(new_nodes[10], new_nodes[6], True))
    edges.append(Edge(new_nodes[11], new_nodes[17], True))
    edges.append(Edge(new_nodes[17], new_nodes[18], True))
    edges.append(Edge(new_nodes[18], new_nodes[19], True))
    edges.append(Edge(new_nodes[19], new_nodes[15], True))
    edges.append(Edge(new_nodes[19], new_nodes[20], True))
    edges.append(Edge(new_nodes[20], new_nodes[27], True))
    edges.append(Edge(new_nodes[21], new_nodes[28], True))
    edges.append(Edge(new_nodes[28], new_nodes[29], True))
    edges.append(Edge(new_nodes[29], new_nodes[24], True))
    edges.append(Edge(new_nodes[30], new_nodes[39], True))
    edges.append(Edge(new_nodes[39], new_nodes[34], True))

def create_first_rooms(world: FantasticFistWorld, nodes: list[Node], edges: list[Edge]):
    if world.options.entrance_rando:
        create_first_rooms_entrance_rando_enabled(world, nodes, edges)
    else:
        create_first_rooms_entrance_rando_disabled(world, nodes, edges)

def create_first_rooms_entrance_rando_enabled(world: FantasticFistWorld, nodes: list[Node], edges: list[Edge]):
    first_rooms: list[Node] = []
    level_nodes: list[Node] = []
    for level_index in ID_TO_LEVEL:
        first_room: Node = Node(append_room_number(ID_TO_LEVEL[level_index].level_name, 1), "First Room", level_index)
        first_rooms.append(first_room)
        nodes.append(first_room)
        level_nodes.append(get_node_from_name(nodes, ID_TO_LEVEL[level_index].level_id))

    the_looking_glass_level: Level = ID_TO_LEVEL[42]
    the_looking_glass_first_room: Node = get_node_from_name(first_rooms, append_room_number(the_looking_glass_level.level_name, 1))
    the_looking_glass_level_node: Node = get_node_from_name(level_nodes, the_looking_glass_level.level_id)
    edges.append(Edge(the_looking_glass_level_node, the_looking_glass_first_room, False))
    first_rooms.remove(the_looking_glass_first_room)
    level_nodes.remove(the_looking_glass_level_node)

    galactic_central_point_level: Level = ID_TO_LEVEL[43]
    galactic_central_point_first_room: Node = get_node_from_name(first_rooms, append_room_number(galactic_central_point_level.level_name, 1))
    galactic_central_point_level_node: Node = get_node_from_name(level_nodes, galactic_central_point_level.level_id)
    edges.append(Edge(galactic_central_point_level_node, galactic_central_point_first_room, False))
    first_rooms.remove(galactic_central_point_first_room)
    level_nodes.remove(galactic_central_point_level_node)

    if world.options.goal == 2:
        home_level: Level = ID_TO_LEVEL[44]
        home_first_room: Node = get_node_from_name(first_rooms, append_room_number(home_level.level_name, 1))
        home_level_node: Node = get_node_from_name(level_nodes, home_level.level_id)
        edges.append(Edge(home_level_node, home_first_room, False))
        first_rooms.remove(home_first_room)
        level_nodes.remove(home_level_node)

    while len(level_nodes) > 0 and len(first_rooms) > 0:
        random_first_room: Node = first_rooms[world.random.randint(0, len(first_rooms) - 1)]
        curr_level_node: Node = level_nodes[0]
        edges.append(Edge(curr_level_node, random_first_room, False))
        first_rooms.remove(random_first_room)
        level_nodes.remove(curr_level_node)

def create_first_rooms_entrance_rando_disabled(world: FantasticFistWorld, nodes: list[Node], edges: list[Edge]):
    for level_index in ID_TO_LEVEL:
        first_room_node: Node = Node(append_room_number(ID_TO_LEVEL[level_index].level_name, 1), "First Room", level_index)
        nodes.append(first_room_node)
        edges.append(Edge(get_node_from_name(nodes, ID_TO_LEVEL[level_index].level_id), first_room_node, False))

def create_rooms(world: FantasticFistWorld, nodes: list[Node], edges: list[Edge]):
    rooms: list[Node] = []
    for level_index in ID_TO_LEVEL:
        level: Level = ID_TO_LEVEL[level_index]
        for room_index in range(level.level_room_count):
            if room_index == 0:
                rooms.append(get_node_from_name(nodes, append_room_number(level.level_name, 1)))
            else:
                room_type: str = "Room"
                if room_index + 1 == level.level_room_count:
                    room_type = "Last Room"
                room: Node = Node(append_room_number(level.level_name, room_index + 1), room_type, level_index)
                room = specialize_room(room)
                rooms.append(room)
                nodes.append(room)

    if world.options.door_rando == 0:
        connect_rooms_door_rando_full_balanced(world, nodes, rooms, edges, False)
    elif world.options.door_rando == 1:
        connect_rooms_door_rando_full_balanced(world, nodes, rooms, edges, True)
    elif world.options.door_rando == 2:
        connect_rooms_door_rando_restricted_disabled(world, rooms, edges, False)
    elif world.options.door_rando == 3:
        connect_rooms_door_rando_restricted_disabled(world, rooms, edges, True)

def specialize_room(room: Node) -> Node:
    if (room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 5)):
        return (Node("Verticality Room 2B", "Side Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 4)):
        return (Node(room.node_name, "Last Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[7].level_name, 6)):
        return (Node("Fist Fight Boss Arena", "Boss Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[10].level_name, 2)):
        return (Node("The Library Room 1B", "Side Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[10].level_name, 3)):
        return (Node("The Library Room 1C", "Side Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[10].level_name, 4)):
        return (Node("The Library Room 1D", "Side Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[16].level_name, 5)):
        return (Node("The Gatekeeper Boss Arena", "Boss Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 3)):
        return (Node(room.node_name, "Split Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 4)):
        return (Node("The Throne Room Room 4A", "Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 9)):
        return (Node("The Throne Room Room 4B", "Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 5)):
        return (Node(room.node_name, "Split Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 6)):
        return (Node("The Throne Room Room 6A", "Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 10)):
        return (Node("The Throne Room Room 6B", "Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 11)):
        return (Node("The Throne Room Boss Arena", "Boss Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[36].level_name, 9)):
        return (Node("The Five Mile Spire Room 7B", "Side Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[36].level_name, 8)):
        return (Node(room.node_name, "Last Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[42].level_name, 6)):
        return (Node("Universal Bearing Collectible The Hive", "Universal Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[42].level_name, 7)):
        return (Node("Universal Bearing Collectible Nyctophobia", "Universal Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[42].level_name, 8)):
        return (Node("Universal Bearing Collectible Various Explosives", "Universal Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[42].level_name, 9)):
        return (Node("Universal Bearing Collectible Introduction", "Universal Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[42].level_name, 5)):
        return (Node(room.node_name, "Last Room", room.level_id))
    
    elif (room.node_name == append_room_number(ID_TO_LEVEL[43].level_name, 4)):
        return (Node("Galactic Central Point Boss Arena 32", "Final Boss Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[43].level_name, 5)):
        return (Node("Galactic Central Point Boss Arena 49", "Final Boss Room", room.level_id))
    elif (room.node_name == append_room_number(ID_TO_LEVEL[43].level_name, 6)):
        return (Node("Galactic Central Point Boss Arena 37", "Final Boss Room", room.level_id))
    
    return room
    
def connect_rooms_door_rando_full_balanced(world: FantasticFistWorld, nodes: list[Node], rooms: list[Node], edges: list[Edge], balanced: bool):
    levels: list[list[Node]] = []
    
    #The Library is 1 room (and 3 side rooms), so it will be added at the end 
    library: Node = get_node_from_name(rooms, append_room_number(ID_TO_LEVEL[10].level_name, 1))
    rooms.remove(library)

    first_rooms: list[Node] = pop_nodes_from_type(rooms, "First Room")
    last_rooms: list[Node] = pop_nodes_from_type(rooms, "Last Room")
    last_rooms += pop_nodes_from_type(rooms, "Boss Room")
    final_boss_rooms: list[Node] = pop_nodes_from_type(rooms, "Final Boss Room")
    side_rooms: list[Node] = pop_nodes_from_type(rooms, "Side Room")
    universal_rooms: list[Node] = pop_nodes_from_type(rooms, "Universal Room")

    #The last room of The Throne Room will be forced to be vanilla 
    throne_room_last_room: Node = get_node_from_name(rooms, append_room_number(ID_TO_LEVEL[27].level_name, 8))
    rooms.remove(throne_room_last_room)

    vanilla_paths: bool = world.options.paths == 0
    levels_that_need_secret_exits: list[int] = []
    last_rooms_with_secret_exits: list[Node] = []
    if vanilla_paths:
        levels_on_map: list[Node] = [get_node_from_name(nodes, ID_TO_LEVEL[1].level_id),
                                     get_node_from_name(nodes, ID_TO_LEVEL[3].level_id),
                                     get_node_from_name(nodes, ID_TO_LEVEL[11].level_id),
                                     get_node_from_name(nodes, ID_TO_LEVEL[19].level_id),
                                     get_node_from_name(nodes, ID_TO_LEVEL[21].level_id),
                                     get_node_from_name(nodes, ID_TO_LEVEL[30].level_id)]
        for level_on_map in levels_on_map:
            for edge in edges:
                if edge.start_node == level_on_map and edge.end_node.node_type == "First Room":
                    levels_that_need_secret_exits.append(edge.end_node.level_id)
                    break

        last_rooms_with_secret_exits.append(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[11].level_name, 4)))
        last_rooms.remove(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[11].level_name, 4)))
        last_rooms_with_secret_exits.append(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[21].level_name, 3)))
        last_rooms.remove(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[21].level_name, 3)))
        last_rooms_with_secret_exits.append(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[30].level_name, 3)))
        last_rooms.remove(get_node_from_name(last_rooms, append_room_number(ID_TO_LEVEL[30].level_name, 3)))

    throne_room_split_path_rooms: list[Node] = []
    for _ in range(4):
        standard_rooms: list[Node] = get_nodes_from_type(rooms, "Room")
        split_path_room: Node = standard_rooms[world.random.randint(0, len(standard_rooms) - 1)]
        while vanilla_paths and (split_path_room.node_name == append_room_number(ID_TO_LEVEL[1].level_name, 2) or
                              split_path_room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 2) or
                              split_path_room.node_name == append_room_number(ID_TO_LEVEL[19].level_name, 4)):
            split_path_room: Node = standard_rooms[world.random.randint(0, len(standard_rooms) - 1)]
        throne_room_split_path_rooms.append(split_path_room)
        rooms.remove(split_path_room)

    for first_room in first_rooms:
        level: list[Node] = []
        level.append(first_room)
        levels.append(level)

    balanced_throne_room_boss_exit_level: list[Node] = levels[world.random.randint(0, len(levels) - 1)]
    balanced_throne_room_boss_exit_level_id: int = balanced_throne_room_boss_exit_level[0].level_id
    while balanced and (balanced_throne_room_boss_exit_level_id == 43 or balanced_throne_room_boss_exit_level_id == 9):
        balanced_throne_room_boss_exit_level: list[Node] = levels[world.random.randint(0, len(levels) - 1)]
        balanced_throne_room_boss_exit_level_id: int = balanced_throne_room_boss_exit_level[0].level_id

    while len(rooms) > 0:
        room: Node = rooms[world.random.randint(0, len(rooms) - 1)]
        level_index = world.random.randint(0, len(levels) - 1)
        level: list[Node] = levels[level_index]

        if vanilla_paths and (room.node_name == append_room_number(ID_TO_LEVEL[1].level_name, 2) or
                              room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 2) or
                              room.node_name == append_room_number(ID_TO_LEVEL[19].level_name, 4)):
            level_with_most_rooms_remaining: list[Node] = None
            most_rooms_remaining: int

            for level_that_needs_secret_exit in levels_that_need_secret_exits:
                level_that_needs_secret_exit_level: list[Node] = None
                for test_level in levels:
                    if test_level[0].level_id == level_that_needs_secret_exit:
                        level_that_needs_secret_exit_level = test_level
                        break
                
                rooms_remaining: int = ID_TO_LEVEL[level_that_needs_secret_exit].level_room_count
                rooms_remaining -= len(level_that_needs_secret_exit_level)
                if level_that_needs_secret_exit == balanced_throne_room_boss_exit_level_id:
                    #If the level with the throne room is on a level with a secret path get it now so the boss fight doesn't compete with the secret path.
                    level_with_most_rooms_remaining = level_that_needs_secret_exit_level
                    most_rooms_remaining = rooms_remaining
                    break
                elif level_with_most_rooms_remaining == None or rooms_remaining > most_rooms_remaining:
                    level_with_most_rooms_remaining = level_that_needs_secret_exit_level
                    most_rooms_remaining = rooms_remaining
                
            level = level_with_most_rooms_remaining
            levels_that_need_secret_exits.remove(level[0].level_id)

        elif balanced:
            room_size = 1
            if (room.node_type == "Split Room"):
                room_size = 3
            elif room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 2) or room.node_name == append_room_number(ID_TO_LEVEL[36].level_name, 7):
                room_size = 2

            rooms_remaining_in_level: int = ID_TO_LEVEL[level[0].level_id].level_room_count

            if level[0].level_id == balanced_throne_room_boss_exit_level_id:
                rooms_remaining_in_level -= 2
            elif level[0].level_id == 43:
                rooms_remaining_in_level -= 3
            else:
                rooms_remaining_in_level -= 1

            if level[0].level_id == 42:
                rooms_remaining_in_level -= 4

            rooms_remaining_in_level -= len(level)

            trys: int = 1

            # Attempt to fit the room into a level, if it can't fit, it's not a big deal.
            while (rooms_remaining_in_level - room_size < 0 and trys < len(levels)):
                level = levels[(level_index + trys) % len(levels)]

                rooms_remaining_in_level = ID_TO_LEVEL[level[0].level_id].level_room_count

                if level[0].level_id == balanced_throne_room_boss_exit_level_id:
                    rooms_remaining_in_level -= 2
                elif level[0].level_id == 43:
                    rooms_remaining_in_level -= 3
                else:
                    rooms_remaining_in_level -= 1

                if level[0].level_id == 42:
                    rooms_remaining_in_level -= 4

                rooms_remaining_in_level -= len(level)

                trys += 1


        level.append(room)
        rooms.remove(room)

        if room.node_type == "Split Room":
            level.append(throne_room_split_path_rooms[0])
            throne_room_split_path_rooms.remove(throne_room_split_path_rooms[0])
            level.append(throne_room_split_path_rooms[0])
            throne_room_split_path_rooms.remove(throne_room_split_path_rooms[0])
        elif room.node_name == append_room_number(ID_TO_LEVEL[3].level_name, 2):
            level.append(get_node_from_name(side_rooms, "Verticality Room 2B"))
        elif room.node_name == append_room_number(ID_TO_LEVEL[36].level_name, 7):
            level.append(get_node_from_name(side_rooms, "The Five Mile Spire Room 7B"))

    for level in levels:
        does_level_need_secret_exit = False
        for level_that_needs_secret_exit in levels_that_need_secret_exits:
            if level[0].level_id == level_that_needs_secret_exit:
                does_level_need_secret_exit = True

        if level[0].level_id == 43:
            #Galactic Central Point has the final boss
            level.extend(final_boss_rooms)

        elif vanilla_paths and does_level_need_secret_exit:
            last_room: Node = last_rooms_with_secret_exits[world.random.randint(0, len(last_rooms_with_secret_exits) - 1)]
            
            level.append(last_room)

            last_rooms_with_secret_exits.remove(last_room)

        else:
            last_room: Node = last_rooms[world.random.randint(0, len(last_rooms) - 1)]
            if balanced:
                if level[0].level_id == balanced_throne_room_boss_exit_level_id:
                    last_room = get_node_from_name(last_rooms, "The Throne Room Boss Arena")
                else:
                    while last_room == get_node_from_name(last_rooms, "The Throne Room Boss Arena"):
                        last_room = last_rooms[world.random.randint(0, len(last_rooms) - 1)]

            level.append(last_room)

            last_rooms.remove(last_room)

            if last_room.level_id == 27:
                level.append(throne_room_last_room)

    for level in levels:
        room_index: int = 0
        while room_index < len(level) - 1:
            if (level[room_index].node_type == "Split Room"):
                edges.append(Edge(level[room_index], level[room_index + 1], False))
                edges.append(Edge(level[room_index], level[room_index + 2], False))
                edges.append(Edge(level[room_index + 1], level[room_index + 3], False))
                edges.append(Edge(level[room_index + 2], level[room_index + 3], False))
                room_index += 3
            elif (level[room_index].node_name == append_room_number(ID_TO_LEVEL[3].level_name, 2) or 
                  level[room_index].node_name == append_room_number(ID_TO_LEVEL[36].level_name, 7)):
                edges.append(Edge(level[room_index], level[room_index + 1], False))
                edges.append(Edge(level[room_index], level[room_index + 2], False))
                room_index += 2
            elif level[0].level_id == 43 and room_index == len(level) - 4:
                edges.append(Edge(level[room_index], level[room_index + 1], False))
                edges.append(Edge(level[room_index], level[room_index + 2], False))
                edges.append(Edge(level[room_index], level[room_index + 3], False))
                room_index += 3
            else:
                edges.append(Edge(level[room_index], level[room_index + 1], False))

    edges.append(Edge(library, get_node_from_name(side_rooms, "The Library Room 1B"), False))
    edges.append(Edge(library, get_node_from_name(side_rooms, "The Library Room 1C"), False))
    edges.append(Edge(library, get_node_from_name(side_rooms, "The Library Room 1D"), False))

    edges.append(Edge(get_node_from_name(first_rooms, append_room_number(ID_TO_LEVEL[42].level_name, 1)), get_node_from_name(universal_rooms, "Universal Bearing Collectible The Hive"), False))
    edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible The Hive"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Nyctophobia"), False))
    edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible Nyctophobia"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Various Explosives"), False))
    edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible Various Explosives"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Introduction"), False))

def connect_rooms_door_rando_restricted_disabled(world: FantasticFistWorld, rooms: list[Node], edges: list[Edge], disabled: bool):
    first_rooms = pop_nodes_from_type(rooms, "First Room")
    last_rooms = pop_nodes_from_type(rooms, "Last Room")
    last_rooms += pop_nodes_from_type(rooms, "Boss Room")
    side_rooms = pop_nodes_from_type(rooms, "Side Room")
    
    for first_room in first_rooms:
        level_id = first_room.level_id
        level: list[Node] = [first_room]
        
        rooms_in_level: list[Node] = []
        for room in rooms:
            if room.level_id == level_id:
                rooms_in_level.append(room)

        last_room_in_level: Node = last_rooms[0]
        for last_room in last_rooms:
            if last_room.level_id == level_id:
                last_room_in_level = last_room
                break

        if level_id == 3:
            # Verticality
            sorted_or_shuffled_rooms = sort_or_shuffle_rooms(world, first_room, rooms_in_level, last_room, disabled, edges)
            edges.append(Edge(get_node_from_name(sorted_or_shuffled_rooms, append_room_number(ID_TO_LEVEL[3].level_name, 2)), get_node_from_name(side_rooms, "Verticality Room 2B"), False))
        elif level_id == 10:
            # The Library
            edges.append(Edge(first_room, get_node_from_name(side_rooms, "The Library Room 1B"), False))
            edges.append(Edge(first_room, get_node_from_name(side_rooms, "The Library Room 1C"), False))
            edges.append(Edge(first_room, get_node_from_name(side_rooms, "The Library Room 1D"), False))
        elif level_id == 27:
            # The Throne Room
            edges.append(Edge(first_room, get_node_from_name(rooms_in_level, "The Throne Room Room 2"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 2"), get_node_from_name(rooms_in_level, "The Throne Room Room 3"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 3"), get_node_from_name(rooms_in_level, "The Throne Room Room 4A"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 3"), get_node_from_name(rooms_in_level, "The Throne Room Room 4B"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 4A"), get_node_from_name(rooms_in_level, "The Throne Room Room 5"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 4B"), get_node_from_name(rooms_in_level, "The Throne Room Room 5"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 5"), get_node_from_name(rooms_in_level, "The Throne Room Room 6A"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 5"), get_node_from_name(rooms_in_level, "The Throne Room Room 6B"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 6A"), get_node_from_name(rooms_in_level, "The Throne Room Room 7"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 6B"), get_node_from_name(rooms_in_level, "The Throne Room Room 7"), False))
            edges.append(Edge(get_node_from_name(rooms_in_level, "The Throne Room Room 7"), last_room, False))
            edges.append(Edge(last_room, get_node_from_name(rooms_in_level, "The Throne Room Room 8"), False))
        elif level_id == 36:
            # The Five Mile Spire
            edges.append(Edge(get_node_from_name(sorted_or_shuffled_rooms, append_room_number(ID_TO_LEVEL[36].level_name, 7)), get_node_from_name(side_rooms, "The Five Mile Spire Room 7B"), False))
        elif level_id == 42:
            # The Looking Glass
            universal_rooms: list[Node] = pop_nodes_from_type(rooms_in_level, "Universal Room")
            sort_or_shuffle_rooms(world, first_room, rooms_in_level, last_room, disabled, edges)
            edges.append(Edge(first_room, get_node_from_name(universal_rooms, "Universal Bearing Collectible The Hive"), False))
            edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible The Hive"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Nyctophobia"), False))
            edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible Nyctophobia"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Various Explosives"), False))
            edges.append(Edge(get_node_from_name(universal_rooms, "Universal Bearing Collectible Various Explosives"), get_node_from_name(universal_rooms, "Universal Bearing Collectible Introduction"), False))
        elif level_id == 43:
            # Galactic Central Point
            flipped: bool
            if disabled:
                flipped = False
            else:
                flipped = world.random.randint(0, 1) == 1

            second_room: Node
            third_room: Node

            if flipped:
                second_room = get_node_from_name(rooms_in_level, append_room_number(ID_TO_LEVEL[43].level_name, 3))
                third_room = get_node_from_name(rooms_in_level, append_room_number(ID_TO_LEVEL[43].level_name, 2))
            else:
                second_room = get_node_from_name(rooms_in_level, append_room_number(ID_TO_LEVEL[43].level_name, 2))
                third_room = get_node_from_name(rooms_in_level, append_room_number(ID_TO_LEVEL[43].level_name, 3))

            edges.append(Edge(first_room, second_room, False))
            edges.append(Edge(second_room, third_room, False))
            edges.append(Edge(third_room, get_node_from_name(rooms_in_level, "Galactic Central Point Boss Arena 32"), False))
            edges.append(Edge(third_room, get_node_from_name(rooms_in_level, "Galactic Central Point Boss Arena 49"), False))
            edges.append(Edge(third_room, get_node_from_name(rooms_in_level, "Galactic Central Point Boss Arena 37"), False))
        else:
            sort_or_shuffle_rooms(world, first_room, rooms_in_level, last_room, disabled, edges)

def sort_or_shuffle_rooms(world: FantasticFistWorld, first_room: Node, rooms: list[Node], last_room: Node, sort: bool, edges: list[Edge]) -> list[Node]:
    sorted_or_shuffled_rooms: list[Node] = []
    if len(rooms) == 0:
        edges.append(Edge(first_room, last_room, False))
        return sorted_or_shuffled_rooms
    
    if sort:
        room_id: int = 2
        while len(rooms) > 0:
            room: Node = get_node_from_name(rooms, append_room_number(ID_TO_LEVEL[first_room.level_id].level_name, room_id))
            sorted_or_shuffled_rooms.append(room)
            rooms.remove(room)
            room_id += 1
    else:
        while len(rooms) > 0:
            room: Node = rooms[world.random.randint(0, len(rooms) - 1)]
            sorted_or_shuffled_rooms.append(room)
            rooms.remove(room)

    edges.append(Edge(first_room, sorted_or_shuffled_rooms[0], False))
    for room_id in range(len(sorted_or_shuffled_rooms) - 1):
        edges.append(Edge(sorted_or_shuffled_rooms[room_id], sorted_or_shuffled_rooms[room_id + 1], False))
    edges.append(Edge(sorted_or_shuffled_rooms[len(sorted_or_shuffled_rooms) - 1], last_room, False))

    return sorted_or_shuffled_rooms

def create_all_regions(world: FantasticFistWorld, nodes: list[Node]) -> None:
    regions: list[Region] = [Region("Menu", world.player, world.multiworld)]
    for node in nodes:
        regions.append(Region(node.node_name, world.player, world.multiworld))

    world.multiworld.regions += regions

def connect_regions(world: FantasticFistWorld, edges: list[Edge]):
    menu_region: Region = world.get_region("Menu")
    first_level_region: Region = world.get_region("1-1")
    menu_region.connect(first_level_region, "Menu to 1-1")

    split_level_id1: int = 1
    split_level_id2: int = 1

    for edge in edges:
        start_node: Node = edge.start_node
        start_region: Region = world.get_region(start_node.node_name)
        end_node: Node = edge.end_node
        end_region: Region = world.get_region(end_node.node_name)

        if start_node.node_type == "Level" and end_node.node_type == "Level":
            start_region.connect(end_region, start_node.node_name + " to " + end_node.node_name)
            if edge.double_sided:
                # Only paths between levels are double sided (for logic purposes)
                end_region.connect(start_region, end_node.node_name + " to " + start_node.node_name)
        elif start_node.node_type == "Level" and end_node.node_type != "Level":
            world.randomized_entrances.append(edge)
            start_region.connect(end_region, start_node.node_name + " Entrance")
        else:
            world.randomized_doors.append(edge)
            if end_node.node_name == "Verticality Room 2B":
                start_region.connect(end_region, start_node.node_name + " Side Door")
            elif end_node.node_name == "The Library Room 1B":
                start_region.connect(end_region, start_node.node_name + " Side Door 1")
            elif end_node.node_name == "The Library Room 1C":
                start_region.connect(end_region, start_node.node_name + " Side Door 2")
            elif end_node.node_name == "The Library Room 1D":
                start_region.connect(end_region, start_node.node_name + " Side Door 3")
            elif end_node.node_name == "The Five Mile Spire Room 7B":
                start_region.connect(end_region, start_node.node_name + " Side Door")
            elif end_node.node_name == "Universal Bearing Collectible The Hive":
                start_region.connect(end_region, start_node.node_name + " Secret Exit")
            elif end_node.node_name == "Galactic Central Point Boss Arena 32":
                start_region.connect(end_region, start_node.node_name + " Boss Heart 1")
            elif end_node.node_name == "Galactic Central Point Boss Arena 49":
                start_region.connect(end_region, start_node.node_name + " Boss Heart 2")
            elif end_node.node_name == "Galactic Central Point Boss Arena 37":
                start_region.connect(end_region, start_node.node_name + " Boss Heart 3")
            elif start_node.node_type == "Split Room" and start_node.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 3):
                start_region.connect(end_region, start_node.node_name + " Door " + str(split_level_id1))
                split_level_id1 += 1
            elif start_node.node_type == "Split Room" and start_node.node_name == append_room_number(ID_TO_LEVEL[27].level_name, 5):
                start_region.connect(end_region, start_node.node_name + " Door " + str(split_level_id2))
                split_level_id2 += 1
            else:
                start_region.connect(end_region, start_node.node_name + " Door")