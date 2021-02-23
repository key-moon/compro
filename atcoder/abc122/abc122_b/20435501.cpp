// detail: https://atcoder.jp/contests/abc122/submissions/20435501
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int res = 0;
  int streak = 0;
  for (var&& c : s) {
    switch (c) {
    case 'A':
    case 'C':
    case 'T':
    case 'G':
      streak++;
      break;
    default:
      streak = 0;
      break;
    }
    chmax(res, streak);
  }
  cout << res << endl;
}
