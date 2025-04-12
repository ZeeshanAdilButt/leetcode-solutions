/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    
    const indices = {};  // val -> index

        // for (let i = 0; i < nums.length; i++) {
        //     indices[nums[i]] = i;
        // }

        for (let i = 0; i < nums.length; i++) {
            let diff = target - nums[i];
            if (indices[diff] !== undefined ) {
                return [i, indices[diff]];
            }
            else{

                indices[nums[i]] = i;
            }

        }

        return [];

};


 