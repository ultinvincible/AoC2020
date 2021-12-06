file = open("input.txt")
Input = file.readlines()
file.close()

mask = ""
mem = {}
for line in Input:
    s0 = line.split(" = ")[0]
    s1 = line.split(" = ")[1][:-1]
    if s0 == "mask":
        mask = s1
    else:
        temp = list(mask)
        # print("".join(temp))
        value = bin(int(s1))[2:]
        # print(" " * (len(temp) - len(value)) + value)
        for i in range(len(temp) - len(value)):
            if temp[i] == "X": temp[i] = "0"
        # print("".join(temp[:-len(value)]))
        for i in range(len(value)):
            if temp[-1 - i] == "X":
                temp[-1 - i] = value[-1 - i]
        # print("".join(temp) + "\n")
        mem[int(s0[4:-1])] = "".join(temp)

result = 0
for value in mem.values():
    result += int(value, base=2)
print(result)

mask = ""
mem = {}
for line in Input:
    # print("line: " + line[:-1])
    s0 = line.split(" = ")[0]
    s1 = line.split(" = ")[1].strip()
    addresses = []
    if s0 == "mask":
        mask = s1
    else:
        float_addr = list(bin(int(s0[4:-1]))[2:].zfill(36))
        addresses = [float_addr]

        for i in range(36):  # each digit
            temp = []  # new addresses
            for a in addresses:  # each address do_& or split into 2 & goes to temp
                if mask[-1 - i] != "X":
                    a[-1 - i] = str(int(a[-1 - i]) | int(mask[-1 - i]))
                else:
                    b = a.copy()
                    b[-1 - i] = "0"
                    temp.append(b)
                    c = a.copy()
                    c[-1 - i] = "1"
                    temp.append(c)
                    # print("i = " + str(i))
                    # print("".join(b) + "|")
                    # print("".join(c) + "|")
            if len(temp) > 0:
                addresses = temp

        # print("".join(float_addr) + ": addr")
        # print(mask[- len(float_addr):] + ": mask")
        # print("Addresses:")
        # for a in addresses:
        #     print("  " + "".join(a))
    for a in addresses:
        mem[int("".join(a), base=2)] = s1
        # print("".join(a))
    # print("mem[" + str(int("".join(a), base=2)) + "] = " + s1)

result = 0
for value in mem.values():
    result += int(value)
print(result)
