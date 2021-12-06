file = open("input.txt")
time = int(file.readline())
Input = file.readline()[:-1]
file.close()

input1 = list(filter(lambda s: s != 'x', Input.split(',')))
min_wait = time
min_bus = 0
for bus in input1:
    bus = int(bus)
    wait = bus - time % bus
    if wait < min_wait:
        min_wait = wait
        min_bus = bus
print(min_wait * min_bus)

input2 = Input.split(',')
start = []
i = 0
for bus in input2:
    if bus != 'x':
        bus = int(bus)
        start.append((bus, bus - i % bus))
    i += 1
# print(start)


def combine(b1, b2):
    o = b1[1]
    while True:
        o += b1[0]
        if (o - b2[1]) % b2[0] == 0:
            return b1[0] * b2[0], o


result = start
while len(result) > 1:
    temp = []
    i = 0
    while i < len(result) - 1:
        temp.append(combine(result[i], result[i + 1]))
        # print(result[i], result[i + 1], temp[-1])
        j = 0
        for r in start:
            # if (temp[-1][1] - r[1]) % r[0] == 0:
            #     print(j)
            j += 1
        i += 2
    if len(result) % 2 == 1:
        temp.append(result[-1])
    result = temp
    # print(result)
print(result[0][1])

# i = 0
# while True:
#     print(i)
#     if all((i + r[1]) % r[0] == 0 for r in requirements):
#         print(i)
#         break
#     i += 1
