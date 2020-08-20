// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2006/judge/4777442/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;


int main() {
	string keys[] = { "", ".,!? ", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
	int n;
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		string s;
		cin >> s;
		string res = "";
		int last = 0;
		int streak = -1;
		for (var&& c : s) {
			var num = c - '0';
			if (num == 0) {
				if (last == 0) continue;
				res += keys[last][streak % keys[last].size()];
				last = 0;
				streak = -1;
			}
			else {
				last = num;
				streak++;
			}
		}
		cout << res << '\n';
	}
}


