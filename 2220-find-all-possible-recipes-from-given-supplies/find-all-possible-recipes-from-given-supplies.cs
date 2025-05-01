public class Solution {

    public IList<string> FindAllRecipes(
        string[] recipes,
        IList<IList<string>> ingredients,
        string[] supplies
    )
     {
        var available = new HashSet<string>(supplies); // initial supplies
        var recipeQueue = new Queue<int>(); // process recipe indices
        var createdRecipes = new List<string>();

        for (int i = 0; i < recipes.Length; i++) {
            recipeQueue.Enqueue(i);
        }

        int lastSize = -1;

        while (available.Count > lastSize) {

            lastSize = available.Count;

            int recipeQueueSize = recipeQueue.Count;

            for (int i = 0; i < recipeQueueSize; i++) {

                int recipeIdx = recipeQueue.Dequeue();
                bool canCreate = true;

                foreach (var ingredient in ingredients[recipeIdx]) {
                    if (!available.Contains(ingredient)) {
                        canCreate = false;
                        break;
                    }
                }

                if (canCreate) {
                    available.Add(recipes[recipeIdx]);
                    createdRecipes.Add(recipes[recipeIdx]);
                } else {
                    recipeQueue.Enqueue(recipeIdx);
                }
            }
        }

        return createdRecipes;
    }
}
