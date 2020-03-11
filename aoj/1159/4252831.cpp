// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1159/judge/4252831/C++14
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
    int ball = r;
    vector<int> hands(n);
    for (int i = 0; true; i = (i + 1) % n) {
        if (ball == 0){
            ball = hands[i];
            hands[i] = 0;
        }
        else{
            hands[i] += 1;
            ball -= 1;
            if (hands[i] == r){
                cout << i << endl;
                return;
            }
        }
    }
}

