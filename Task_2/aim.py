import sympy

func_str = "x ** 3 - 10 * x + 2"
func = sympy.sympify(func_str)
func_d = sympy.diff(func)
func_dd = sympy.diff(func_d)

func_l = sympy.lambdify("x", func, "numpy")
func_d_l = sympy.lambdify("x", func_d, "numpy")
func_dd_l = sympy.lambdify("x", func_dd, "numpy")


def f_str():
    return func_str


def f(x):
    return func_l(x)


def f_d(x):
    return func_d_l(x)


def f_dd(x):
    return func_dd_l(x)
