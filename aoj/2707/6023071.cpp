// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2707/judge/6023071/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  ll n, k;
  cin >> n >> k;
  ll prev = 0;
  for (int i = 1; i < n; i++) {
    prev += 1 + prev / (k - 1);
  }
  cout << prev << endl;
}
