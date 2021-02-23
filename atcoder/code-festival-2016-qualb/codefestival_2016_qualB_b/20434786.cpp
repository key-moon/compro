// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/20434786
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, a, b;
  cin >> n >> a >> b;
  string s;
  cin >> s;
  int num = 1;
  int cnt = 0;
  for (var&& c : s) {
    bool flag = false;
    flag |= (c == 'a' && cnt < a + b);
    flag |= (c == 'b' && num <= b && cnt < a + b);
    if (flag) {
      cout << "Yes" << endl;
      cnt++;
    }
    else {
      cout << "No" << endl;
    }
    if (c == 'b') num++;
  }

}
