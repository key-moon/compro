// detail: https://codeforces.com/contest/825/submission/108143567
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
  ll dig = 1;
  ll res = 0;
  int streak = 0;
  for (int i = n - 1; i >= 0; i--) {
    if (s[i] == '0') {
      res += dig * streak;
      dig *= 10;
      streak = 0;
    }
    else streak++;
  }
  res += dig * streak;
  cout << res << endl;
}
