main = do
    days_input <- getLine
    cat_food_input <- getLine
    first_cat_food_per_day_input <- getLine
    second_cat_food_per_day_input <- getLine

    let days = read days_input :: Int
    let cat_food = read cat_food_input :: Int 
    let first_cat_food_per_day = read first_cat_food_per_day_input :: Double
    let second_cat_food_per_day = read second_cat_food_per_day_input :: Double

    let first_cat_food = (fromIntegral days :: Double) * first_cat_food_per_day
    let second_cat_food = (fromIntegral days :: Double) * second_cat_food_per_day

    let total_cat_food = first_cat_food + second_cat_food

    if total_cat_food <= (fromIntegral cat_food :: Double)
        then do
            putStrLn("The cats are well fed.")

            let left_food = ceiling ((fromIntegral cat_food :: Double) - total_cat_food)
            let left_food_output = show left_food :: String

            putStrLn(left_food_output ++ " kilos of food left.")
        else do
            putStrLn("The cats are hungry.")

            let needed_food = floor (total_cat_food - (fromIntegral cat_food :: Double))
            let needed_food_output = show needed_food :: String

            putStrLn(needed_food_output ++ " more kilos of food are needed.")