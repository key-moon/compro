// detail: https://atcoder.jp/contests/abc052/submissions/20436158
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
  string s;
  cin >> s;
  n = 0;
  int res = n;
  for (var&& c : s) {
    if (c == 'I') n++;
    else n--;
    chmax(res, n);
  }
  cout << res << endl;
}