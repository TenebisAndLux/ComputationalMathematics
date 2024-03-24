# print(algorithm.det(A))
# print(np.linalg.det(A))

# print(algorithm.norm(A))
# print(np.linalg.norm(A, ord=float("inf")))

# print(algorithm.cond(A))
# print(np.linalg.cond(A, p=float("inf")))

# koef = np.matrix([[1 / 10000000000000, 1/100000000000, 1, 1]], dtype=np.float64)
# for i in range(A.shape[0]):
#     A[i, :] *= koef[0, i]
#     B[i, :] *= koef[0, i]

# print(A)
# print(algorithm.cond(A))
# print(B)