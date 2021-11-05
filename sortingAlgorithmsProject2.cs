import random


def main():
    # Create the main list to populate, then a secondary list to hold temporary information,

    mainlist = []
    secondlist = []

    # Default Value for number of numbers to be added to mainlist
    userNumNumbers = 10000

    # This loop runs until the users gives a valid numerical input between 10 and 20,000.
    # Once they do, a random number is appended to the mainlist as many times as the numerical value.
    # If invalid input is input,

    waitValidInput = True
    while waitValidInput:
        try:
            userPrompt = int(input("Choose the number of numbers generated (10 - 20,000): "))
            if userPrompt >= 10 and userPrompt <= 20000:
                for i in range(userPrompt):
                    mainlist.append(random.randint(1, 20000))
                    waitValidInput = False
            else:
                waitValidInput = True
                print("Invalid number. Please choose between 10 and 20,000" + "\n")
        except ValueError:
            print("Please use a numerical value" + "\n")
            waitValidInput = True

    # Add each of the values in mainlist to secondlist

    for x in mainlist:
        secondlist.append(x)

    # Run bubbleSort and return the values to bubbleswaps and bubbleloops

    bubbleswaps, bubbleloops = bubbleSort(secondlist)

    # Set secondlist to hold no values, then repopulate it with the values of the original list.

    secondlist = []

    for x in mainlist:
        secondlist.append(x)

    # Run selectionSort and return the values to selectionswaps and selectionloops

    selectionswaps, selectionloops = selectionSort(secondlist)

    # Sets the values for the three rows of the results display

    rows = [('ALGORITHM', 'LOOP COUNT', 'DATA MOVEMENT'), ('Bubble', bubbleloops,
                                                           bubbleswaps), ('Selection', selectionswaps, selectionloops)]

    # Display results. Formatting creates three columns.

    print("\n" + "SORT ALGORITHM RUN EFFICIENCY")
    for x in rows:
        print('{:<15} {:>10} {:>20}'.format(x[0], x[1], x[2]))

    input()


def bubbleSort(testList):
    ## This function runs the bubbleSort algorithm on testList, records the loopCount and swaps,
    ## then returns them. These results are displayed to allow the user to test the performance of both algorithms.

    listSize = len(testList)
    swaps = 0
    loopCount = 0

    for k in range(0, listSize - 1):
        for i in range(0, listSize - k - 1):
            loopCount += 1
            if testList[i] > testList[i + 1]:
                swaps += 1
                lstemp = testList[i + 1]
                testList[i + 1] = testList[i]
                testList[i] = lstemp

    return swaps, loopCount


def selectionSort(list):
    ## This function runs the selectionSort algorithm on testList, records the loopCount and swaps,
    ## then returns them.

    swaps = 0
    loopCount = 0

    for k in range(len(list) - 1):

        minIndex = k
        minValue = list[k]

        loopCount += 1
        for index in range(k + 1, len(list)):
            if list[index] < minValue:
                minValue = list[index]
                minIndex = index

        swaps += 1
        list[minIndex], list[k] = list[k], list[minIndex]

    return swaps, loopCount


# Run
main()