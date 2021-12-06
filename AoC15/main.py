def play(turns):
    Input = [13, 16, 0, 12, 15, 1]
    game = {}  # dict of last index found
    for i in range(len(Input)):
        game[Input[i]] = i
        # print(Input[i])
    say = 0
    for i in range(6, turns - 1):  # turn 7 to 2020
        # print("i = " + str(i))
        if say in game.keys():  # spoken
            # print(say, end="|")
            # print(game[say], end="|")
            temp = say
            say = i - game[say]  # said how many turns ago
            game[temp] = i  # update index
            # print(say)
        else:  # not spoken
            game[say] = i  # set index for first time
            # print(say)
            say = 0
    print(say)


play(2020)
play(30000000)
