file = open("input.txt")
inp = file.read().split("\n\n")
file.close()

fields = []
ranges = []

for line in inp[0].split("\n"):
    fields.append(line.split(":")[0])
    range=[]
    for s in line.split(":")[1].strip().split(" or "):
        range.extend(s.split("-"))
    ranges.append(range)

mine=inp[1].split("\n")[1]

for line in inp[2].split("\n")[1:]:
    for number,field in zip(line.split(","),fields):
        if
