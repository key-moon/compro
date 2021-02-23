// detail: https://atcoder.jp/contests/abc140/submissions/20437486
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  ll res = 0;
  int prev;
  cin >> prev;
  res += prev;
  for (int i = 1; i < n - 1; i++) {
    int cur;
    cin >> cur;
    res += min(prev, cur);
    prev = cur;
  }
  res += prev;
  cout << res << endl;
}
