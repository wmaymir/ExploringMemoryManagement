How to execute the code and recreate the results:

1. Run the game in the editor.

2. Resource loading system and texture management optimization:
- The memory is allocated before the first frame
- Press "X" to unload the texture and de-allocate memory

3. Object pooling system:
- Press "S" to spawn a sphere.
- If there are more than 10 spheres spawned in at a single time, then after a sphere's lifetime ends, this happens:
Those not in the original 10 (maxSize parameter) are destroyed, while the first 10 are preserved and de-activated.
