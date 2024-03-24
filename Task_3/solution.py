import algorithm
import numpy as np


def iterative_method(
        A: np.matrix, B: np.matrix, eps: float = 0.0001, max_iterations: int = 10000
) -> np.matrix:
    if A.shape[0] != A.shape[1] or A.shape[0] != B.shape[0] or B.shape[1] != 1:
        return None

    n = A.shape[0]

    alpha = np.copy(A)
    beta = np.copy(B)

    for i in range(n):
        j = algorithm.swap_max_row(alpha, i)

        if alpha[i, i] == 0:
            return None

        beta[[i, j], :] = beta[[j, i], :]

    swaps = []
    for i in range(n):
        j = algorithm.swap_max_column(alpha, i)

        if alpha[i, i] == 0:
            return None

        swaps.append((i, j))

    for i in range(n):
        beta[i, 0] = beta[i, 0] / alpha[i, i]

    X = np.copy(beta)

    for i in range(n):
        for j in range(n):
            if i == j:
                continue

            alpha[i, j] = -(alpha[i, j] / alpha[i, i])

        alpha[i, i] = 0

    print(algorithm.cond(alpha))

    if algorithm.cond(alpha) >= 1.0:
        return None

    i = 0
    while i < max_iterations:
        i += 1

        X_old = np.copy(X)
        X = np.add(np.matmul(alpha, X), beta)

        if np.sum(np.abs(X - X_old)) < eps:
            break

    for i, j in swaps:
        X[[i, j], :] = X[[j, i], :]

    return X
