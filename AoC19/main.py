# file = open("input.txt")
# inp = file.read().split("\n\n")
# file.close()
inp = ["""0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: "a"
5: "b\""""]

tempDict = {}
for line in inp[0].split("\n"):
    index, rule_str = line.split(": ")
    tempDict[int(index)] = rule_str

rules = ["" for i in range(max(tempDict.keys()) + 1)]
for k in sorted(tempDict.keys()):
    rules[k] = tempDict[k]

for x in range(len(rules)):
    for i, rule in enumerate(rules):
        if not any(char.isnumeric() for char in rule):
            rules[i] = rule.replace("\"", "")
            for i1, rule1 in enumerate(rules):
                rules[i1] = rule1.replace(str(i), rule)

for index1 in (rule for rule in rules if rule not in ("a", "b")):
    for subRule in index1:
        for i, ruleIndex in enumerate(subRule):
            if rules[int(ruleIndex)] in ("a", "b"):
                subRule[i] = rules[int(ruleIndex)]
# for rule in rules:
#     for i, subRule in enumerate(rule):
#         while isinstance(subRule, list):
#             subRule = subRule[0]
#         else:
#             rule[i] = subRule
# new_rules = []
# for rule in rules:
#     if rule not in new_rules:
#         new_rules.append(rule)

print()
