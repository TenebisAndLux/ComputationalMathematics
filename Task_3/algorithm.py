import numpy as np


def det(matrix: np.matrix):
    if matrix.shape[0] != matrix.shape[1]:
        return None
    if matrix.shape[0] == 1:
        return matrix[0, 0]

    return _det(matrix)


def _det(matrix: np.matrix):
    matrix, swaps = triangle(np.copy(matrix))
    if matrix is None:
        return 0.0

    n = matrix.shape[0]
    determinant = (-1) ** swaps
    for i in range(n):
        determinant *= matrix[i, i]

    return determinant


def triangle(matrix: np.matrix):
    swaps = 0
    n = matrix.shape[0]

    for i in range(n):
        if matrix[i, i] == 0:
            if not swap_first_non_zero(matrix, i)[0]:
                return None, swaps
            swaps += 1

        for j in range(i + 1, n):
            matrix[j, :] = matrix[j, :] - matrix[i, :] * (matrix[j, i] / matrix[i, i])

    return matrix, swaps


def swap_first_non_zero(matrix, i):
    n = matrix.shape[0]
    for j in range(i, n):
        if matrix[j, i] != 0:
            if i != j:
                matrix[[i, j], :] = matrix[[j, i], :]
            return True, j
    return False, -1


def swap_max_row(matrix, i):
    n = matrix.shape[0]
    col_max = abs(matrix[i, i])
    max_j = i
    for j in range(i, n):
        if abs(matrix[j, i]) > col_max:
            col_max = abs(matrix[j, i])
            max_j = j

    if i != max_j:
        matrix[[i, max_j], :] = matrix[[max_j, i], :]

    return max_j


def swap_max_column(matrix, i):
    n = matrix.shape[0]
    row_max = abs(matrix[i, i])
    max_j = i
    for j in range(i, n):
        if abs(matrix[i, j]) > row_max and abs(matrix[i, i]) - abs(matrix[j, j]) > 0.0:
            row_max = abs(matrix[i, j])
            max_j = j

    if i != max_j:
        matrix[:, [i, max_j]] = matrix[:, [max_j, i]]

    return max_j


def norm(matrix: np.matrix):
    n = matrix.shape[0]
    m = matrix.shape[1]

    m_norm = float("-inf")
    for i in range(n):
        s = 0.0
        for j in range(m):
            s += abs(matrix[i, j])

        if s > m_norm:
            m_norm = s

    return m_norm


def cond(matrix: np.matrix):
    return norm(matrix) * norm(np.linalg.inv(matrix))
