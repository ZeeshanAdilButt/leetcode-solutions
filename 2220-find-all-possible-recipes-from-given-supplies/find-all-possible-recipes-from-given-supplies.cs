public class Solution {
    public IList<string> FindAllRecipes(
        string[] recipes,
        IList<IList<string>> ingredients,
        string[] supplies
    )
    {
        var suppliesRashan = new HashSet<string>(supplies);
        var recipeQueue = new Queue<int>();
        var createdRecipes = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            recipeQueue.Enqueue(i);
        }

        bool addedNewItem = true;

        while (addedNewItem) {
            addedNewItem = false;

            int recipeQueueSize = recipeQueue.Count;

            for (int i = 0; i < recipeQueueSize; i++) {
                int recipeIdx = recipeQueue.Dequeue();
                bool canCreate = true;

                foreach (var ingredient in ingredients[recipeIdx]) {
                    if (!suppliesRashan.Contains(ingredient)) {
                        canCreate = false;
                        break;
                    }
                }

                if (canCreate) {
                    suppliesRashan.Add(recipes[recipeIdx]);
                    createdRecipes.Add(recipes[recipeIdx]);
                    addedNewItem = true; // we made progress!
                } else {
                    recipeQueue.Enqueue(recipeIdx); // try again later
                }
            }
        }

        return createdRecipes;
    }
}
