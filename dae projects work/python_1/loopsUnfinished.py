def Displaymenu():
    print("welcome to my calculator")
    print("1. addition")
    print("2. subtraction")
    print("3. multiplication")
    print("4. division")

def addNumbers( firstNumber, secondNumber ):
    sum = firstNumber + secondNumber
    print( "The sum of " + firstNumber + " and " + secondNumber + " is " + sum ) 

def subtractNumbers( firstNumber, secondNumber ):
    difference = firstNumber - secondNumber
    print( "The difference of " + firstNumber + " and " + secondNumber + " is " + difference ) 

def multiplyingNumbers( firstNumber, secondNumber ):
    Product = firstNumber * secondNumber
    print( "The product of " + firstNumber + " and " + secondNumber + " is " + Product ) 

def dividingNumbers( firstNumber, secondNumber ):
    divide = firstNumber / secondNumber
    print( "The answer of " + firstNumber + " and " + secondNumber + " is " + divide ) 
def main(): #this is the main program, everything will support
    #1. display menu to user
    allfeatures=("addition", "subtraction", "division", "multiplication")
    # Displaymenu()
    intinput("please select an option")
    firstNumber
    secondNumber
    #start loop
    # for currentFeature in allfeatures
    #     print(currentFeature)

    #advance loop
    # print(allfeatures[2])
    for currentFeature in range(len(allfeatures))
        print(allfeatures[currentFeatureindex])

    if useroption = 1:
        addNumbers()
    elif useroption = 2:
        subtractNumbers()
    elif useroption = 3:
        multiplyingNumbers()
    elif useroption = 4:
        dividingNumbers()
main()

# userFirstnumber = input("what's your first number?")
# userSecondnumber = input("what's your first number?")

# addNumbers(userFirstnumber, userSecondnumber)

# addNumbers(4 , 5)
# addNumbers(6 , 11)

# def sayTageline(): #loop
#     print("stop playing")
#     print("stop playing")

# sayTageline() #calling it so it'll work