import math

Input = []
file = open("input.txt")
for line in file:
    Input.append(line)
file.close()
coords_angle = [0, 0, 90]


def move(i):
    coords_angle[i[0]] += i[1]
    # print("{};{}".format(i, a))


for line in Input:
    line = line[:-1]
    instr = line[:1]
    amount = int(line[1:])
    direction = {"N": (1, amount), "E": (0, amount), "S": (1, -amount),
                 "W": (0, -amount), "L": (2, -amount), "R": (2, amount)}
    instrF = {0: direction["N"], 90: direction["E"], 180: direction["S"], 270: direction["W"]}
    if instr != "F":
        move(direction[instr])
    else:
        move(instrF[coords_angle[2] % 360])
print(abs(coords_angle[0]) + abs(coords_angle[1]))

moved = [0, 0]
waypoint = [10, 1]
for line in Input:
    line = line[:-1]
    # print(line)
    instr = line[:1]
    amount = int(line[1:])
    if instr == "F":
        moved[0] += waypoint[0] * amount
        moved[1] += waypoint[1] * amount
        # print("MV" + str(moved))
    elif instr in ("L", "R"):
        for i in range(math.floor(amount / 90)):
            rotate = {"L": [-waypoint[1], waypoint[0]],
                      "R": [waypoint[1], -waypoint[0]]}
            waypoint = rotate[instr]
            # print("WP" + str(waypoint))
    else:
        direction = {"N": (1, amount), "E": (0, amount),
                     "S": (1, -amount), "W": (0, -amount)}
        waypoint[direction[instr][0]] += direction[instr][1]
        # print("WP" + str(waypoint))
print(abs(moved[0]) + abs(moved[1]))
