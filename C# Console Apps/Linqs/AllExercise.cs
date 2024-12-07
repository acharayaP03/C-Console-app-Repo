﻿namespace C__Console_Apps.Linqs;

public class AllExercise
{
    public static bool AreAllPetsOfTheSameType(IEnumerable<Pet> pets)
    {
        //return pets.All(pet => pet.PetType == PetType.Dog) ||
        //    pets.All(pet => pet.PetType == PetType.Cat) ||
        //    pets.All(pet => pet.PetType == PetType.Fish);

        // Enum.GetValues(typeof(Pet)) -> generates array type
        // Cast<PetType> converts into IEnumerable which can be queried or can use linq
        var allPetTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();
        return allPetTypes.Any(petType => pets.All(pet => pet.PetType == petType));
    }

    public static bool AreAllWordsOfTheSameLength_Refactored(List<string> words)
    {
        return words.All(word => word.Length == words[0].Length);
    }

    //do not modify this method
    public static bool AreAllWordsOfTheSameLength(List<string> words)
    {
        if (words.Count == 0 || words.Count == 1)
        {
            return true;
        }
        var length0 = words[0].Length;
        for (int i = 1; i < words.Count; ++i)
        {
            if (words[i].Length != length0)
            {
                return false;
            }
        }
        return true;
    }
}

public class Pet
{
    public int Id { get; }
    public string Name { get; }
    public PetType PetType { get; }
    public float Weight { get; }

    public Pet(int id, string name, PetType petType, float weight)
    {
        Id = id;
        Name = name;
        PetType = petType;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
    }
}

public enum PetType
{
    Cat,
    Dog,
    Fish
}


