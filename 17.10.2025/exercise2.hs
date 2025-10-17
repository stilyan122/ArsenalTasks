multiplyNumbers = do
    num1Input <- getLine
    num2Input <- getLine

    let number1 = read num1Input :: Int
    let number2 = read num2Input :: Int

    let multiplied = number1 * number2

    let output = show multiplied :: String
    putStrLn output