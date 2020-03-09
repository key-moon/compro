// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1147/judge/4247767/C++14
#include <bits/stdc++.h>

#define var auto
#define long long long
#define ll long
#define Max std::max
#define Min std::min
#define Abs std::abs

void Solve();

using namespace std;

int main() {
    while (true) {
        Solve();
    }
}

void Solve() {
    int n;
    cin >> n;
    if (n == 0) exit(0);
    long sum = 0;
    long max = INT32_MIN;
    long min = INT32_MAX;
    for (int i = 0; i < n; ++i) {
        long a;
        cin >> a;
        sum += a;
        max = Max(max, a);
        min = Min(min, a);
    }
    cout << (sum - max - min) / (n - 2) << endl;
}

