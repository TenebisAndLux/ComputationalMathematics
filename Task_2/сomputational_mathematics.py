def half_div_method(f, f_d, a, b, max_iter=10_000, eps=0.00001):
    x_n = (a + b) / 2
    i = 0
    while abs(f(x_n)) >= eps and i < max_iter:
        x_n = (a + b) / 2

        f_ = f(x_n)
        if f_ == 0:
            break

        if f(a) * f_ < 0:
            b = x_n
        else:
            a = x_n
        i += 1
    return x_n


def chord_method(f, f_d, f_dd, a, b, max_iter=1_000_000, eps=0.01):
    x_n = (a + b) / 2
    i = 0
    while abs(f(x_n)) >= eps and i < max_iter:
        X = a
        if f(X) * f_dd(X) <= 0:
            X = b
            if f(X) * f_dd(X) <= 0:
                return None

        x_n = x_n - f(x_n) * (X - x_n) / (f(X) - f(x_n))
        i += 1

    return x_n


def newtons_method(f, f_d, a, b, max_iter=10_000, eps=0.00001):
    x_n = a
    i = 0
    while abs(f(x_n)) >= eps and i < max_iter:
        x_n = x_n - f(x_n) / f_d(x_n)
        i += 1
    return x_n


def modified_newtons_method(f, f_d, a, b, max_iter=1_000_000, eps=0.01):
    x_n = a
    f_d_0 = f_d(x_n)
    i = 0

    while abs(f(x_n)) >= eps and i < max_iter:
        x_n = x_n - f(x_n) / f_d_0
        i += 1
    return x_n


def combined_method(f, f_d, a, b, max_iter=10_000, eps=0.00001):
    x_n = a
    y_n = b
    i = 0

    while abs(x_n - y_n) >= eps and i < max_iter:
        x_n = x_n - f(x_n) / f_d(x_n)
        y_n = y_n - f(y_n) * (x_n - y_n) / (f(x_n) - f(y_n))
        i += 1
    return (x_n + y_n) / 2


def iterative_method(f, f_d, a, b, max_iter=10_000, eps=0.0001):
    def phi(x):
        return x - f(x) / f_d(x)

    i = 0
    x = phi(a)

    while abs(f(x)) >= eps and i < max_iter:
        x = phi(x)
        i += 1
    return x
