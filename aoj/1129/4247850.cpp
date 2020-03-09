// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1129/judge/4247850/C++14
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
    int n, r;
    cin >> n >> r;
    if (n == 0 && r == 0) exit(0);
    var pile = new vector<int>(n);
    iota(pile->begin(), pile->end(), 1);
    reverse(pile->begin(), pile->end());
    for (int i = 0; i < r; ++i) {
        var newPile = new vector<int>();
        int p, c;
        cin >> p >> c;
        for (int j = p - 1; j < p + c - 1; ++j) {
            newPile->push_back((*pile)[j]);
        }
        for (int j = 0; j < p - 1; ++j) {
            newPile->push_back((*pile)[j]);
        }
        for (int j = p + c - 1; j < n; ++j) {
            newPile->push_back((*pile)[j]);
        }
        pile = newPile;
    }
    cout << (*pile)[0] << endl;
}

