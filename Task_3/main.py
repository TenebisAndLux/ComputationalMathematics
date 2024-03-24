import numpy as np

import solution

A = np.matrix(
    [
        [14.4, -5.3, 14.3, -12.7],
        [23.4, -14.2, -5.4, 2.1],
        [6.3, -13.2, -6.5, 14.3],
        [5.6, 8.8, -6.7, -23.8],
    ],
    dtype=np.float64,
)

B = np.matrix([[-14.4, 6.6, 9.4, 7.3]], dtype=np.float64).T

X = np.linalg.inv(A) * B

print(solution.iterative_method(A, B))
print(X)
