// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0338/judge/3863333/C++
#include <bits/stdc++.h>
using namespace std;

int gcd(int a, int b) {
    while (true)
    {
        if (b == 0) return a;
        a %= b;
        if (a == 0) return b;
        b %= a;
    }
}

int main() {
    int w, h, c;
    cin >> w >> h >> c;
    int g = gcd(w, h);
    cout << c * (h / g) * (w / g) << endl;
}

