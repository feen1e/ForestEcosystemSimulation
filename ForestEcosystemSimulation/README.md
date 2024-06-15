<a name='assembly'></a>
# ForestEcosystemSimulation

## Contents

- [Animal](#T-ForestEcosystemSimulation-Animals-Animal 'ForestEcosystemSimulation.Animals.Animal')
  - [Random](#F-ForestEcosystemSimulation-Animals-Animal-Random 'ForestEcosystemSimulation.Animals.Animal.Random')
  - [Diet](#P-ForestEcosystemSimulation-Animals-Animal-Diet 'ForestEcosystemSimulation.Animals.Animal.Diet')
  - [Energy](#P-ForestEcosystemSimulation-Animals-Animal-Energy 'ForestEcosystemSimulation.Animals.Animal.Energy')
  - [Health](#P-ForestEcosystemSimulation-Animals-Animal-Health 'ForestEcosystemSimulation.Animals.Animal.Health')
  - [Hunger](#P-ForestEcosystemSimulation-Animals-Animal-Hunger 'ForestEcosystemSimulation.Animals.Animal.Hunger')
  - [LifeLength](#P-ForestEcosystemSimulation-Animals-Animal-LifeLength 'ForestEcosystemSimulation.Animals.Animal.LifeLength')
  - [MaxHealth](#P-ForestEcosystemSimulation-Animals-Animal-MaxHealth 'ForestEcosystemSimulation.Animals.Animal.MaxHealth')
  - [Priority](#P-ForestEcosystemSimulation-Animals-Animal-Priority 'ForestEcosystemSimulation.Animals.Animal.Priority')
  - [Size](#P-ForestEcosystemSimulation-Animals-Animal-Size 'ForestEcosystemSimulation.Animals.Animal.Size')
  - [Speed](#P-ForestEcosystemSimulation-Animals-Animal-Speed 'ForestEcosystemSimulation.Animals.Animal.Speed')
  - [Thirst](#P-ForestEcosystemSimulation-Animals-Animal-Thirst 'ForestEcosystemSimulation.Animals.Animal.Thirst')
  - [X](#P-ForestEcosystemSimulation-Animals-Animal-X 'ForestEcosystemSimulation.Animals.Animal.X')
  - [Y](#P-ForestEcosystemSimulation-Animals-Animal-Y 'ForestEcosystemSimulation.Animals.Animal.Y')
  - [Drink()](#M-ForestEcosystemSimulation-Animals-Animal-Drink 'ForestEcosystemSimulation.Animals.Animal.Drink')
  - [Eat(food)](#M-ForestEcosystemSimulation-Animals-Animal-Eat-ForestEcosystemSimulation-TileContents-Food-Food- 'ForestEcosystemSimulation.Animals.Animal.Eat(ForestEcosystemSimulation.TileContents.Food.Food)')
  - [MakeDecision(priorities,tileInfos,map,animals)](#M-ForestEcosystemSimulation-Animals-Animal-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Animal.MakeDecision(System.Collections.Generic.List{System.Int32},System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo},ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Animal-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Animal.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
  - [Move(x,y)](#M-ForestEcosystemSimulation-Animals-Animal-Move-System-Int32,System-Int32- 'ForestEcosystemSimulation.Animals.Animal.Move(System.Int32,System.Int32)')
  - [Rest()](#M-ForestEcosystemSimulation-Animals-Animal-Rest 'ForestEcosystemSimulation.Animals.Animal.Rest')
  - [Scout(height,width,map,animals)](#M-ForestEcosystemSimulation-Animals-Animal-Scout-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Animal.Scout(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
  - [UsedEnergy()](#M-ForestEcosystemSimulation-Animals-Animal-UsedEnergy 'ForestEcosystemSimulation.Animals.Animal.UsedEnergy')
- [Bear](#T-ForestEcosystemSimulation-Animals-Bear 'ForestEcosystemSimulation.Animals.Bear')
  - [Strength](#P-ForestEcosystemSimulation-Animals-Bear-Strength 'ForestEcosystemSimulation.Animals.Bear.Strength')
  - [SuccessfulHunts](#P-ForestEcosystemSimulation-Animals-Bear-SuccessfulHunts 'ForestEcosystemSimulation.Animals.Bear.SuccessfulHunts')
  - [Hunt(herbivore)](#M-ForestEcosystemSimulation-Animals-Bear-Hunt-ForestEcosystemSimulation-Animals-Herbivore- 'ForestEcosystemSimulation.Animals.Bear.Hunt(ForestEcosystemSimulation.Animals.Herbivore)')
  - [Hunt(carnivore)](#M-ForestEcosystemSimulation-Animals-Bear-Hunt-ForestEcosystemSimulation-Animals-Carnivore- 'ForestEcosystemSimulation.Animals.Bear.Hunt(ForestEcosystemSimulation.Animals.Carnivore)')
- [Berries](#T-ForestEcosystemSimulation-TileContents-Food-Berries 'ForestEcosystemSimulation.TileContents.Food.Berries')
  - [AddTime()](#M-ForestEcosystemSimulation-TileContents-Food-Berries-AddTime 'ForestEcosystemSimulation.TileContents.Food.Berries.AddTime')
- [Burrow](#T-ForestEcosystemSimulation-TileContents-Burrow 'ForestEcosystemSimulation.TileContents.Burrow')
  - [IsOccupied](#P-ForestEcosystemSimulation-TileContents-Burrow-IsOccupied 'ForestEcosystemSimulation.TileContents.Burrow.IsOccupied')
  - [Occupied()](#M-ForestEcosystemSimulation-TileContents-Burrow-Occupied 'ForestEcosystemSimulation.TileContents.Burrow.Occupied')
- [Carnivore](#T-ForestEcosystemSimulation-Animals-Carnivore 'ForestEcosystemSimulation.Animals.Carnivore')
  - [Strength](#P-ForestEcosystemSimulation-Animals-Carnivore-Strength 'ForestEcosystemSimulation.Animals.Carnivore.Strength')
  - [SuccessfulHunts](#P-ForestEcosystemSimulation-Animals-Carnivore-SuccessfulHunts 'ForestEcosystemSimulation.Animals.Carnivore.SuccessfulHunts')
  - [Hunt(herbivore)](#M-ForestEcosystemSimulation-Animals-Carnivore-Hunt-ForestEcosystemSimulation-Animals-Herbivore- 'ForestEcosystemSimulation.Animals.Carnivore.Hunt(ForestEcosystemSimulation.Animals.Herbivore)')
  - [Hunt(omnivore)](#M-ForestEcosystemSimulation-Animals-Carnivore-Hunt-ForestEcosystemSimulation-Animals-Omnivore- 'ForestEcosystemSimulation.Animals.Carnivore.Hunt(ForestEcosystemSimulation.Animals.Omnivore)')
  - [MakeDecision(priorities,tileInfos,map,animals)](#M-ForestEcosystemSimulation-Animals-Carnivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Carnivore.MakeDecision(System.Collections.Generic.List{System.Int32},System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo},ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
- [Deer](#T-ForestEcosystemSimulation-Animals-Deer 'ForestEcosystemSimulation.Animals.Deer')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Deer-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Deer.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
- [Fish](#T-ForestEcosystemSimulation-TileContents-Food-Fish 'ForestEcosystemSimulation.TileContents.Food.Fish')
  - [AddTime()](#M-ForestEcosystemSimulation-TileContents-Food-Fish-AddTime 'ForestEcosystemSimulation.TileContents.Food.Fish.AddTime')
- [Food](#T-ForestEcosystemSimulation-TileContents-Food-Food 'ForestEcosystemSimulation.TileContents.Food.Food')
  - [Count](#P-ForestEcosystemSimulation-TileContents-Food-Food-Count 'ForestEcosystemSimulation.TileContents.Food.Food.Count')
  - [IsPlant](#P-ForestEcosystemSimulation-TileContents-Food-Food-IsPlant 'ForestEcosystemSimulation.TileContents.Food.Food.IsPlant')
  - [MaxCount](#P-ForestEcosystemSimulation-TileContents-Food-Food-MaxCount 'ForestEcosystemSimulation.TileContents.Food.Food.MaxCount')
  - [TimeSinceRegen](#P-ForestEcosystemSimulation-TileContents-Food-Food-TimeSinceRegen 'ForestEcosystemSimulation.TileContents.Food.Food.TimeSinceRegen')
  - [TimeToRegen](#P-ForestEcosystemSimulation-TileContents-Food-Food-TimeToRegen 'ForestEcosystemSimulation.TileContents.Food.Food.TimeToRegen')
  - [AddTime()](#M-ForestEcosystemSimulation-TileContents-Food-Food-AddTime 'ForestEcosystemSimulation.TileContents.Food.Food.AddTime')
  - [Eaten(amount)](#M-ForestEcosystemSimulation-TileContents-Food-Food-Eaten-System-Int32- 'ForestEcosystemSimulation.TileContents.Food.Food.Eaten(System.Int32)')
  - [Regenerate()](#M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate 'ForestEcosystemSimulation.TileContents.Food.Food.Regenerate')
- [ForestEcosystemSimulation](#T-ForestEcosystemSimulation-ForestEcosystemSimulation 'ForestEcosystemSimulation.ForestEcosystemSimulation')
  - [_animalSymbols](#F-ForestEcosystemSimulation-ForestEcosystemSimulation-_animalSymbols 'ForestEcosystemSimulation.ForestEcosystemSimulation._animalSymbols')
  - [_iterations](#F-ForestEcosystemSimulation-ForestEcosystemSimulation-_iterations 'ForestEcosystemSimulation.ForestEcosystemSimulation._iterations')
  - [Animals](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-Animals 'ForestEcosystemSimulation.ForestEcosystemSimulation.Animals')
  - [Height](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-Height 'ForestEcosystemSimulation.ForestEcosystemSimulation.Height')
  - [NumBear](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumBear 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumBear')
  - [NumDeer](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumDeer 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumDeer')
  - [NumFox](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumFox 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumFox')
  - [NumHare](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumHare 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumHare')
  - [NumRacoon](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumRacoon 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumRacoon')
  - [NumWolf](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumWolf 'ForestEcosystemSimulation.ForestEcosystemSimulation.NumWolf')
  - [Tiles](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-Tiles 'ForestEcosystemSimulation.ForestEcosystemSimulation.Tiles')
  - [Width](#P-ForestEcosystemSimulation-ForestEcosystemSimulation-Width 'ForestEcosystemSimulation.ForestEcosystemSimulation.Width')
  - [AddAnimals()](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-AddAnimals 'ForestEcosystemSimulation.ForestEcosystemSimulation.AddAnimals')
  - [AddSpecificAnimal(random,numAnimals,createAnimal)](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-AddSpecificAnimal-System-Random,System-Int32,System-Func{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.ForestEcosystemSimulation.AddSpecificAnimal(System.Random,System.Int32,System.Func{ForestEcosystemSimulation.Animals.Animal})')
  - [CheckMap()](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-CheckMap 'ForestEcosystemSimulation.ForestEcosystemSimulation.CheckMap')
  - [IncreaseTimeSinceRegen()](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-IncreaseTimeSinceRegen 'ForestEcosystemSimulation.ForestEcosystemSimulation.IncreaseTimeSinceRegen')
  - [PrintMap()](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-PrintMap 'ForestEcosystemSimulation.ForestEcosystemSimulation.PrintMap')
  - [RunSimulation(iterations)](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-RunSimulation-System-Int32- 'ForestEcosystemSimulation.ForestEcosystemSimulation.RunSimulation(System.Int32)')
  - [UpdateAnimalPositions()](#M-ForestEcosystemSimulation-ForestEcosystemSimulation-UpdateAnimalPositions 'ForestEcosystemSimulation.ForestEcosystemSimulation.UpdateAnimalPositions')
- [Fox](#T-ForestEcosystemSimulation-Animals-Fox 'ForestEcosystemSimulation.Animals.Fox')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Fox-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Fox.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
- [Grass](#T-ForestEcosystemSimulation-TileContents-Food-Grass 'ForestEcosystemSimulation.TileContents.Food.Grass')
  - [AddTime()](#M-ForestEcosystemSimulation-TileContents-Food-Grass-AddTime 'ForestEcosystemSimulation.TileContents.Food.Grass.AddTime')
- [Hare](#T-ForestEcosystemSimulation-Animals-Hare 'ForestEcosystemSimulation.Animals.Hare')
  - [IsHidden](#P-ForestEcosystemSimulation-Animals-Hare-IsHidden 'ForestEcosystemSimulation.Animals.Hare.IsHidden')
  - [Hide(burrow)](#M-ForestEcosystemSimulation-Animals-Hare-Hide-ForestEcosystemSimulation-TileContents-Burrow- 'ForestEcosystemSimulation.Animals.Hare.Hide(ForestEcosystemSimulation.TileContents.Burrow)')
  - [MakeDecision(priorities,tileInfos,map,animals)](#M-ForestEcosystemSimulation-Animals-Hare-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Hare.MakeDecision(System.Collections.Generic.List{System.Int32},System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo},ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Hare-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Hare.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
- [Herbivore](#T-ForestEcosystemSimulation-Animals-Herbivore 'ForestEcosystemSimulation.Animals.Herbivore')
  - [MakeDecision(priorities,tileInfos,map,animals)](#M-ForestEcosystemSimulation-Animals-Herbivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Herbivore.MakeDecision(System.Collections.Generic.List{System.Int32},System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo},ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
- [Omnivore](#T-ForestEcosystemSimulation-Animals-Omnivore 'ForestEcosystemSimulation.Animals.Omnivore')
  - [MakeDecision(priorities,tileInfos,map,animals)](#M-ForestEcosystemSimulation-Animals-Omnivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}- 'ForestEcosystemSimulation.Animals.Omnivore.MakeDecision(System.Collections.Generic.List{System.Int32},System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo},ForestEcosystemSimulation.Terrain.Terrain[][],System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal})')
- [Racoon](#T-ForestEcosystemSimulation-Animals-Racoon 'ForestEcosystemSimulation.Animals.Racoon')
  - [Climb(height,width,map)](#M-ForestEcosystemSimulation-Animals-Racoon-Climb-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Racoon.Climb(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Racoon-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Racoon.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')
- [Terrain](#T-ForestEcosystemSimulation-Terrain-Terrain 'ForestEcosystemSimulation.Terrain.Terrain')
  - [#ctor(type)](#M-ForestEcosystemSimulation-Terrain-Terrain-#ctor-System-Int32- 'ForestEcosystemSimulation.Terrain.Terrain.#ctor(System.Int32)')
  - [Contents](#F-ForestEcosystemSimulation-Terrain-Terrain-Contents 'ForestEcosystemSimulation.Terrain.Terrain.Contents')
  - [Type](#P-ForestEcosystemSimulation-Terrain-Terrain-Type 'ForestEcosystemSimulation.Terrain.Terrain.Type')
  - [GenerateMap(height,width)](#M-ForestEcosystemSimulation-Terrain-Terrain-GenerateMap-System-Int32,System-Int32- 'ForestEcosystemSimulation.Terrain.Terrain.GenerateMap(System.Int32,System.Int32)')
- [TileContents](#T-ForestEcosystemSimulation-TileContents-TileContents 'ForestEcosystemSimulation.TileContents.TileContents')
- [TileInfo](#T-ForestEcosystemSimulation-Animals-Animal-TileInfo 'ForestEcosystemSimulation.Animals.Animal.TileInfo')
  - [#ctor(Content,X,Y)](#M-ForestEcosystemSimulation-Animals-Animal-TileInfo-#ctor-System-Int32,System-Int32,System-Int32- 'ForestEcosystemSimulation.Animals.Animal.TileInfo.#ctor(System.Int32,System.Int32,System.Int32)')
  - [Content](#P-ForestEcosystemSimulation-Animals-Animal-TileInfo-Content 'ForestEcosystemSimulation.Animals.Animal.TileInfo.Content')
  - [X](#P-ForestEcosystemSimulation-Animals-Animal-TileInfo-X 'ForestEcosystemSimulation.Animals.Animal.TileInfo.X')
  - [Y](#P-ForestEcosystemSimulation-Animals-Animal-TileInfo-Y 'ForestEcosystemSimulation.Animals.Animal.TileInfo.Y')
- [Tree](#T-ForestEcosystemSimulation-TileContents-Tree 'ForestEcosystemSimulation.TileContents.Tree')
- [Wolf](#T-ForestEcosystemSimulation-Animals-Wolf 'ForestEcosystemSimulation.Animals.Wolf')
  - [Hunt(herbivore)](#M-ForestEcosystemSimulation-Animals-Wolf-Hunt-ForestEcosystemSimulation-Animals-Herbivore- 'ForestEcosystemSimulation.Animals.Wolf.Hunt(ForestEcosystemSimulation.Animals.Herbivore)')
  - [Move(height,width,map)](#M-ForestEcosystemSimulation-Animals-Wolf-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Wolf.Move(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])')

<a name='T-ForestEcosystemSimulation-Animals-Animal'></a>
## Animal `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents the base class for all animals in the forest ecosystem simulation.

<a name='F-ForestEcosystemSimulation-Animals-Animal-Random'></a>
### Random `constants`

##### Summary

Random number generator shared by all animals.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Diet'></a>
### Diet `property`

##### Summary

The diet type of the animal (0: Herbivore, 1: Omnivore, 2: Carnivore).

<a name='P-ForestEcosystemSimulation-Animals-Animal-Energy'></a>
### Energy `property`

##### Summary

The energy level of the animal (0.0 to 1.0).

<a name='P-ForestEcosystemSimulation-Animals-Animal-Health'></a>
### Health `property`

##### Summary

The current health of the animal.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Hunger'></a>
### Hunger `property`

##### Summary

The hunger level of the animal (0.0 to 1.0).

<a name='P-ForestEcosystemSimulation-Animals-Animal-LifeLength'></a>
### LifeLength `property`

##### Summary

Lifespan of the animal in simulation iterations.

<a name='P-ForestEcosystemSimulation-Animals-Animal-MaxHealth'></a>
### MaxHealth `property`

##### Summary

The maximum health of the animal.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Priority'></a>
### Priority `property`

##### Summary

List of action priorities for the animal's decision-making.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Size'></a>
### Size `property`

##### Summary

The size of the animal, influencing interactions with other animals.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Speed'></a>
### Speed `property`

##### Summary

The speed of the animal, affecting movement distance.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Thirst'></a>
### Thirst `property`

##### Summary

The thirst level of the animal (0.0 to 1.0).

<a name='P-ForestEcosystemSimulation-Animals-Animal-X'></a>
### X `property`

##### Summary

The X coordinate of the animal on the map.

<a name='P-ForestEcosystemSimulation-Animals-Animal-Y'></a>
### Y `property`

##### Summary

The Y coordinate of the animal on the map.

<a name='M-ForestEcosystemSimulation-Animals-Animal-Drink'></a>
### Drink() `method`

##### Summary

Simulates the animal drinking water.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-Animals-Animal-Eat-ForestEcosystemSimulation-TileContents-Food-Food-'></a>
### Eat(food) `method`

##### Summary

Simulates the animal eating food.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| food | [ForestEcosystemSimulation.TileContents.Food.Food](#T-ForestEcosystemSimulation-TileContents-Food-Food 'ForestEcosystemSimulation.TileContents.Food.Food') | The food to eat. |

<a name='M-ForestEcosystemSimulation-Animals-Animal-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### MakeDecision(priorities,tileInfos,map,animals) `method`

##### Summary

Determines the animal's next action based on its priorities and the surrounding environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorities | [System.Collections.Generic.List{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32}') | List of actions sorted by priority. |
| tileInfos | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}') | Information about surrounding tiles. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | List of animals in the simulation. |

<a name='M-ForestEcosystemSimulation-Animals-Animal-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Moves the animal randomly to a valid location on the map, avoiding river tiles (Type 1).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The 2D array representing the terrain map. |

<a name='M-ForestEcosystemSimulation-Animals-Animal-Move-System-Int32,System-Int32-'></a>
### Move(x,y) `method`

##### Summary

Moves the animal to the specified coordinates.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The new X coordinate. |
| y | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The new Y coordinate. |

<a name='M-ForestEcosystemSimulation-Animals-Animal-Rest'></a>
### Rest() `method`

##### Summary

Simulates the animal resting, replenishing its energy.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-Animals-Animal-Scout-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### Scout(height,width,map,animals) `method`

##### Summary

Allows the animal to scout its surroundings and make a decision based on the information gathered.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The 2D array representing the terrain map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | The list of all animals in the simulation. |

<a name='M-ForestEcosystemSimulation-Animals-Animal-UsedEnergy'></a>
### UsedEnergy() `method`

##### Summary

Updates the animal's energy, hunger, and thirst after performing an action.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-Animals-Bear'></a>
## Bear `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a bear in the forest ecosystem simulation.

<a name='P-ForestEcosystemSimulation-Animals-Bear-Strength'></a>
### Strength `property`

##### Summary

The strength of the bear, influencing hunting abilities.

<a name='P-ForestEcosystemSimulation-Animals-Bear-SuccessfulHunts'></a>
### SuccessfulHunts `property`

##### Summary

Number of successful hunts the bear performed

<a name='M-ForestEcosystemSimulation-Animals-Bear-Hunt-ForestEcosystemSimulation-Animals-Herbivore-'></a>
### Hunt(herbivore) `method`

##### Summary

Simulates the omnivore hunting a herbivore.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| herbivore | [ForestEcosystemSimulation.Animals.Herbivore](#T-ForestEcosystemSimulation-Animals-Herbivore 'ForestEcosystemSimulation.Animals.Herbivore') | The herbivore target. |

<a name='M-ForestEcosystemSimulation-Animals-Bear-Hunt-ForestEcosystemSimulation-Animals-Carnivore-'></a>
### Hunt(carnivore) `method`

##### Summary

Simulates the omnivore hunting a carnivore.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| carnivore | [ForestEcosystemSimulation.Animals.Carnivore](#T-ForestEcosystemSimulation-Animals-Carnivore 'ForestEcosystemSimulation.Animals.Carnivore') | The carnivore target. |

<a name='T-ForestEcosystemSimulation-TileContents-Food-Berries'></a>
## Berries `type`

##### Namespace

ForestEcosystemSimulation.TileContents.Food

##### Summary

Represents a berries food source in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-TileContents-Food-Berries-AddTime'></a>
### AddTime() `method`

##### Summary

Increments the time since the food was last regenerated with a chance to increase [MaxCount](#P-ForestEcosystemSimulation-TileContents-Food-Food-MaxCount 'ForestEcosystemSimulation.TileContents.Food.Food.MaxCount'), and triggers [Regenerate](#M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate 'ForestEcosystemSimulation.TileContents.Food.Food.Regenerate') if necessary.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-TileContents-Burrow'></a>
## Burrow `type`

##### Namespace

ForestEcosystemSimulation.TileContents

##### Summary

Represents a burrow tile content in the forest ecosystem simulation.

<a name='P-ForestEcosystemSimulation-TileContents-Burrow-IsOccupied'></a>
### IsOccupied `property`

##### Summary

Value indicating whether the burrow is currently occupied.

<a name='M-ForestEcosystemSimulation-TileContents-Burrow-Occupied'></a>
### Occupied() `method`

##### Summary

Toggles the occupancy status of the burrow.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-Animals-Carnivore'></a>
## Carnivore `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Abstract base class representing a carnivorous animal in the forest ecosystem simulation.

<a name='P-ForestEcosystemSimulation-Animals-Carnivore-Strength'></a>
### Strength `property`

##### Summary

Strength of the carnivore, influencing its hunting success.

<a name='P-ForestEcosystemSimulation-Animals-Carnivore-SuccessfulHunts'></a>
### SuccessfulHunts `property`

##### Summary

Number of successful hunts the carnivore performed

<a name='M-ForestEcosystemSimulation-Animals-Carnivore-Hunt-ForestEcosystemSimulation-Animals-Herbivore-'></a>
### Hunt(herbivore) `method`

##### Summary

Simulates a hunt on a herbivore animal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| herbivore | [ForestEcosystemSimulation.Animals.Herbivore](#T-ForestEcosystemSimulation-Animals-Herbivore 'ForestEcosystemSimulation.Animals.Herbivore') | The herbivore target. |

<a name='M-ForestEcosystemSimulation-Animals-Carnivore-Hunt-ForestEcosystemSimulation-Animals-Omnivore-'></a>
### Hunt(omnivore) `method`

##### Summary

Simulates a hunt on an omnivore animal.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| omnivore | [ForestEcosystemSimulation.Animals.Omnivore](#T-ForestEcosystemSimulation-Animals-Omnivore 'ForestEcosystemSimulation.Animals.Omnivore') | The omnivore target. |

<a name='M-ForestEcosystemSimulation-Animals-Carnivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### MakeDecision(priorities,tileInfos,map,animals) `method`

##### Summary

Determines the carnivore's next action based on its priorities and surrounding environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorities | [System.Collections.Generic.List{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32}') | List of actions sorted by priority. |
| tileInfos | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}') | Information about surrounding tiles. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | List of animals in the simulation. |

<a name='T-ForestEcosystemSimulation-Animals-Deer'></a>
## Deer `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a deer in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Deer-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Moves the deer randomly to a valid location on the map, avoiding river tiles (Type 1).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The 2D array representing the terrain map. |

<a name='T-ForestEcosystemSimulation-TileContents-Food-Fish'></a>
## Fish `type`

##### Namespace

ForestEcosystemSimulation.TileContents.Food

##### Summary

Represents a fish food source in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-TileContents-Food-Fish-AddTime'></a>
### AddTime() `method`

##### Summary

Increments the time since the food was last regenerated with a chance to increase [Count](#P-ForestEcosystemSimulation-TileContents-Food-Food-Count 'ForestEcosystemSimulation.TileContents.Food.Food.Count') property, and triggers [Regenerate](#M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate 'ForestEcosystemSimulation.TileContents.Food.Food.Regenerate') if necessary.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-TileContents-Food-Food'></a>
## Food `type`

##### Namespace

ForestEcosystemSimulation.TileContents.Food

##### Summary

Abstract base class for food sources in the forest ecosystem simulation.

<a name='P-ForestEcosystemSimulation-TileContents-Food-Food-Count'></a>
### Count `property`

##### Summary

The current amount of food available at this source.

<a name='P-ForestEcosystemSimulation-TileContents-Food-Food-IsPlant'></a>
### IsPlant `property`

##### Summary

Indicates whether the food is a plant or not.

<a name='P-ForestEcosystemSimulation-TileContents-Food-Food-MaxCount'></a>
### MaxCount `property`

##### Summary

The maximum amount of food available at this source.

<a name='P-ForestEcosystemSimulation-TileContents-Food-Food-TimeSinceRegen'></a>
### TimeSinceRegen `property`

##### Summary

The time that has passed since the food source was last regenerated.

<a name='P-ForestEcosystemSimulation-TileContents-Food-Food-TimeToRegen'></a>
### TimeToRegen `property`

##### Summary

The time it takes for the food source to regenerate after being depleted.

<a name='M-ForestEcosystemSimulation-TileContents-Food-Food-AddTime'></a>
### AddTime() `method`

##### Summary

Increments the time since the food was last regenerated, and triggers [Regenerate](#M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate 'ForestEcosystemSimulation.TileContents.Food.Food.Regenerate') if necessary.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-TileContents-Food-Food-Eaten-System-Int32-'></a>
### Eaten(amount) `method`

##### Summary

Reduces the amount of food available after it's eaten.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| amount | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of food eaten. |

<a name='M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate'></a>
### Regenerate() `method`

##### Summary

Regenerates the food source to its maximum amount.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-ForestEcosystemSimulation'></a>
## ForestEcosystemSimulation `type`

##### Namespace

ForestEcosystemSimulation

##### Summary

Simulates a forest ecosystem with various animal species.

<a name='F-ForestEcosystemSimulation-ForestEcosystemSimulation-_animalSymbols'></a>
### _animalSymbols `constants`

##### Summary

Dictionary mapping animal types to their display symbols.

<a name='F-ForestEcosystemSimulation-ForestEcosystemSimulation-_iterations'></a>
### _iterations `constants`

##### Summary

Number of iterations to run the simulation for.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-Animals'></a>
### Animals `property`

##### Summary

List of animals currently in the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-Height'></a>
### Height `property`

##### Summary

Height of the simulation map.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumBear'></a>
### NumBear `property`

##### Summary

Number of Bears to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumDeer'></a>
### NumDeer `property`

##### Summary

Number of deer to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumFox'></a>
### NumFox `property`

##### Summary

Number of foxes to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumHare'></a>
### NumHare `property`

##### Summary

Number of hares to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumRacoon'></a>
### NumRacoon `property`

##### Summary

Number of racoons to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-NumWolf'></a>
### NumWolf `property`

##### Summary

Number of wolves to be added to the simulation.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-Tiles'></a>
### Tiles `property`

##### Summary

2D array representing the terrain of the simulation map.

<a name='P-ForestEcosystemSimulation-ForestEcosystemSimulation-Width'></a>
### Width `property`

##### Summary

Width of the simulation map.

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-AddAnimals'></a>
### AddAnimals() `method`

##### Summary

Adds animals to the simulation based on the configured numbers for each type.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-AddSpecificAnimal-System-Random,System-Int32,System-Func{ForestEcosystemSimulation-Animals-Animal}-'></a>
### AddSpecificAnimal(random,numAnimals,createAnimal) `method`

##### Summary

Adds a specified number of animals of a specific type to the simulation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| random | [System.Random](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Random 'System.Random') | Random number generator for positioning animals. |
| numAnimals | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of animals to add. |
| createAnimal | [System.Func{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{ForestEcosystemSimulation.Animals.Animal}') | A function that creates an instance of the animal type. |

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-CheckMap'></a>
### CheckMap() `method`

##### Summary

Prints information about animals and each tile in the map, including terrain type and contents.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-IncreaseTimeSinceRegen'></a>
### IncreaseTimeSinceRegen() `method`

##### Summary

Increments the time since food sources have regenerated.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-PrintMap'></a>
### PrintMap() `method`

##### Summary

Prints a visual representation of the simulation map with animals.

##### Parameters

This method has no parameters.

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-RunSimulation-System-Int32-'></a>
### RunSimulation(iterations) `method`

##### Summary

Runs the forest ecosystem simulation for the specified number of iterations.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| iterations | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of iterations to run. |

<a name='M-ForestEcosystemSimulation-ForestEcosystemSimulation-UpdateAnimalPositions'></a>
### UpdateAnimalPositions() `method`

##### Summary

Updates the positions of animals in the simulation list.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-Animals-Fox'></a>
## Fox `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a fox in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Fox-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Moves the fox randomly to a valid location on the map, avoiding river tiles (Type 1).
Moves two times when starting from a meadow ([](#N-ForestEcosystemSimulation-Terrain 'ForestEcosystemSimulation.Terrain') of type 2).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The 2D array representing the terrain map. |

<a name='T-ForestEcosystemSimulation-TileContents-Food-Grass'></a>
## Grass `type`

##### Namespace

ForestEcosystemSimulation.TileContents.Food

##### Summary

Represents a grass food source in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-TileContents-Food-Grass-AddTime'></a>
### AddTime() `method`

##### Summary

Increments the time since the food was last regenerated with a chance to decrease [TimeToRegen](#P-ForestEcosystemSimulation-TileContents-Food-Food-TimeToRegen 'ForestEcosystemSimulation.TileContents.Food.Food.TimeToRegen'), and triggers [Regenerate](#M-ForestEcosystemSimulation-TileContents-Food-Food-Regenerate 'ForestEcosystemSimulation.TileContents.Food.Food.Regenerate') if necessary.

##### Parameters

This method has no parameters.

<a name='T-ForestEcosystemSimulation-Animals-Hare'></a>
## Hare `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a hare in the forest ecosystem simulation.

<a name='P-ForestEcosystemSimulation-Animals-Hare-IsHidden'></a>
### IsHidden `property`

##### Summary

Indicates whether this herbivore is currently hidden in a burrow.

<a name='M-ForestEcosystemSimulation-Animals-Hare-Hide-ForestEcosystemSimulation-TileContents-Burrow-'></a>
### Hide(burrow) `method`

##### Summary

Simulates the herbivore hiding in a burrow.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| burrow | [ForestEcosystemSimulation.TileContents.Burrow](#T-ForestEcosystemSimulation-TileContents-Burrow 'ForestEcosystemSimulation.TileContents.Burrow') | The burrow to hide in. |

<a name='M-ForestEcosystemSimulation-Animals-Hare-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### MakeDecision(priorities,tileInfos,map,animals) `method`

##### Summary

Determines the hare's next action based on its priorities and surrounding environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorities | [System.Collections.Generic.List{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32}') | List of actions sorted by priority. |
| tileInfos | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}') | Information about surrounding tiles. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | List of animals in the simulation. |

<a name='M-ForestEcosystemSimulation-Animals-Hare-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Overrides the base Move method to handle leaving a burrow if hidden.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |

<a name='T-ForestEcosystemSimulation-Animals-Herbivore'></a>
## Herbivore `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Abstract base class representing a herbivorous animal in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Herbivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### MakeDecision(priorities,tileInfos,map,animals) `method`

##### Summary

Determines the herbivore's next action based on its priorities and surrounding environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorities | [System.Collections.Generic.List{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32}') | List of actions sorted by priority. |
| tileInfos | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}') | Information about surrounding tiles. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | List of animals in the simulation. |

<a name='T-ForestEcosystemSimulation-Animals-Omnivore'></a>
## Omnivore `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Abstract base class representing an omnivorous animal in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Omnivore-MakeDecision-System-Collections-Generic-List{System-Int32},System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal-TileInfo},ForestEcosystemSimulation-Terrain-Terrain[][],System-Collections-Generic-List{ForestEcosystemSimulation-Animals-Animal}-'></a>
### MakeDecision(priorities,tileInfos,map,animals) `method`

##### Summary

Determines the omnivore's next action based on its priorities and surrounding environment.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorities | [System.Collections.Generic.List{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Int32}') | List of actions sorted by priority. |
| tileInfos | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal.TileInfo}') | Information about surrounding tiles. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |
| animals | [System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{ForestEcosystemSimulation.Animals.Animal}') | List of animals in the simulation. |

<a name='T-ForestEcosystemSimulation-Animals-Racoon'></a>
## Racoon `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a racoon in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Racoon-Climb-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Climb(height,width,map) `method`

##### Summary

Simulates the omnivore climbing to a new position.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |

<a name='M-ForestEcosystemSimulation-Animals-Racoon-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Overrides the base Move method to allow climbing by calling [Climb](#M-ForestEcosystemSimulation-Animals-Racoon-Climb-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]- 'ForestEcosystemSimulation.Animals.Racoon.Climb(System.Int32,System.Int32,ForestEcosystemSimulation.Terrain.Terrain[][])').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The simulation map. |

<a name='T-ForestEcosystemSimulation-Terrain-Terrain'></a>
## Terrain `type`

##### Namespace

ForestEcosystemSimulation.Terrain

##### Summary

Represents a single tile in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Terrain-Terrain-#ctor-System-Int32-'></a>
### #ctor(type) `constructor`

##### Summary

Initializes a new instance of the [Terrain](#T-ForestEcosystemSimulation-Terrain-Terrain 'ForestEcosystemSimulation.Terrain.Terrain') class with the specified type.
Randomly assigns contents based on the terrain type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The type of terrain (0: Forest, 1: River, 2: Meadow). |

<a name='F-ForestEcosystemSimulation-Terrain-Terrain-Contents'></a>
### Contents `constants`

##### Summary

Contents of the tile (Tree, Berries, Fish, Grass, Burrow, or null if empty).

<a name='P-ForestEcosystemSimulation-Terrain-Terrain-Type'></a>
### Type `property`

##### Summary

Type of the terrain (0: Forest, 1: River, 2: Meadow).

<a name='M-ForestEcosystemSimulation-Terrain-Terrain-GenerateMap-System-Int32,System-Int32-'></a>
### GenerateMap(height,width) `method`

##### Summary

Generates a random terrain map with the specified height and width.

##### Returns

A 2D array of Terrain objects representing the generated map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |

<a name='T-ForestEcosystemSimulation-TileContents-TileContents'></a>
## TileContents `type`

##### Namespace

ForestEcosystemSimulation.TileContents

##### Summary

Abstract base class representing the contents of a tile in the forest ecosystem simulation.

<a name='T-ForestEcosystemSimulation-Animals-Animal-TileInfo'></a>
## TileInfo `type`

##### Namespace

ForestEcosystemSimulation.Animals.Animal

##### Summary

A record representing information about a tile in the animal's vicinity.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Content | [T:ForestEcosystemSimulation.Animals.Animal.TileInfo](#T-T-ForestEcosystemSimulation-Animals-Animal-TileInfo 'T:ForestEcosystemSimulation.Animals.Animal.TileInfo') | The content type of the tile (0: Food, 1: Tree, 2: Burrow, 3: Water, 4: Herbivore, 5: Omnivore, 6: Carnivore). |

<a name='M-ForestEcosystemSimulation-Animals-Animal-TileInfo-#ctor-System-Int32,System-Int32,System-Int32-'></a>
### #ctor(Content,X,Y) `constructor`

##### Summary

A record representing information about a tile in the animal's vicinity.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Content | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The content type of the tile (0: Food, 1: Tree, 2: Burrow, 3: Water, 4: Herbivore, 5: Omnivore, 6: Carnivore). |
| X | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The X coordinate of the tile. |
| Y | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The Y coordinate of the tile. |

<a name='P-ForestEcosystemSimulation-Animals-Animal-TileInfo-Content'></a>
### Content `property`

##### Summary

The content type of the tile (0: Food, 1: Tree, 2: Burrow, 3: Water, 4: Herbivore, 5: Omnivore, 6: Carnivore).

<a name='P-ForestEcosystemSimulation-Animals-Animal-TileInfo-X'></a>
### X `property`

##### Summary

The X coordinate of the tile.

<a name='P-ForestEcosystemSimulation-Animals-Animal-TileInfo-Y'></a>
### Y `property`

##### Summary

The Y coordinate of the tile.

<a name='T-ForestEcosystemSimulation-TileContents-Tree'></a>
## Tree `type`

##### Namespace

ForestEcosystemSimulation.TileContents

##### Summary

Represents a tree tile content in the forest ecosystem simulation.

<a name='T-ForestEcosystemSimulation-Animals-Wolf'></a>
## Wolf `type`

##### Namespace

ForestEcosystemSimulation.Animals

##### Summary

Represents a wolf in the forest ecosystem simulation.

<a name='M-ForestEcosystemSimulation-Animals-Wolf-Hunt-ForestEcosystemSimulation-Animals-Herbivore-'></a>
### Hunt(herbivore) `method`

##### Summary

Simulates a hunt on a herbivore animal. If the animal is an [Hare](#T-ForestEcosystemSimulation-Animals-Hare 'ForestEcosystemSimulation.Animals.Hare') additional strength is added.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| herbivore | [ForestEcosystemSimulation.Animals.Herbivore](#T-ForestEcosystemSimulation-Animals-Herbivore 'ForestEcosystemSimulation.Animals.Herbivore') | The herbivore target. |

<a name='M-ForestEcosystemSimulation-Animals-Wolf-Move-System-Int32,System-Int32,ForestEcosystemSimulation-Terrain-Terrain[][]-'></a>
### Move(height,width,map) `method`

##### Summary

Moves the wolf randomly to a valid location on the map, avoiding river tiles (Type 1).
Moves two times when starting from a forest ([](#N-ForestEcosystemSimulation-Terrain 'ForestEcosystemSimulation.Terrain') of type 0).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The height of the map. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The width of the map. |
| map | [ForestEcosystemSimulation.Terrain.Terrain[][]](#T-ForestEcosystemSimulation-Terrain-Terrain[][] 'ForestEcosystemSimulation.Terrain.Terrain[][]') | The 2D array representing the terrain map. |
