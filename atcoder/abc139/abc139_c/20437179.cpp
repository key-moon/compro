// detail: https://atcoder.jp/contests/abc139/submissions/20437179
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
  int res = 0;
  int streak = 0;
  int prev;
  cin >> prev;
  for (int i = 1; i < n; i++) {
    int h;
    cin >> h;
    if (prev >= h) streak++;
    else streak = 0;
    prev = h;
    chmax(res, streak);
  }
  cout << res << endl;
}
